using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SA.Application.Account;
using SA.Application.Email;
using SA.Application.Security;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.WebApi.Controllers
{
    [Route("api/Users")]
    public class UsersController : BaseController<User>
    {
        private readonly ISecurityService _securityService;
        private readonly IEntityRepository<Customer> _customerRepository;
        private readonly IEntityRepository<UserActivation> _userActivationRepository;
        private readonly IUserEmailFactory _userEmailFactory;
        private readonly IConfiguration _configuration;

        public UsersController(
            IEntityRepository<User> repository,
            ISecurityService securityService,
            IEntityRepository<Customer> customerRepository,
            IEntityRepository<UserActivation> userActivationRepository,
            IUserEmailFactory userEmailFactory,
            IConfiguration configuration)
            : base(repository)
        {
            _securityService = securityService;
            _customerRepository = customerRepository;
            _userActivationRepository = userActivationRepository;
            _userEmailFactory = userEmailFactory;
            _configuration = configuration;
        }

        [Authorize("read:messages")]
        [Route("LoadByNameAndToken")]
        [HttpGet("{uName}/{token}")]
        public async Task<IActionResult> LoadByNameAndToken(string uName, string token)
            => Json(await _repository.GetOneAsync<User>(x => x.UserName == uName
                && x.Token == token));

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            user.Password = _securityService.GetMD5HashData(user.Password);
            user.Language = user.Customer.Address.Country.Language;
            user.Customer.Address.Country = null;

            var newUser = await _repository.AddAsync(user);

            if (newUser.Id > 0)
            {
                var token = Guid.NewGuid().ToString();
                var activation = await _userActivationRepository.AddAsync(new UserActivation
                {
                    Created = DateTime.Now,
                    IsUsed = false,
                    UserId = newUser.Id,
                    Token = token,
                });

                if (activation.Id > 0)
                {
                    _userEmailFactory.SendActivationEmail(user, activation);
                }
            }

            return Redirect($"{_configuration["Web:Url"]}/successfully-registered");
        }

        [HttpGet]
        [Authorize("admin")]
        [Route("getAllUsersForAdmin")]
        public async Task<IActionResult> GetAllUsersForAdmin()
            => Json(await _repository
                .GetAllAsync<UserSimpleDto, bool>(order: u => u.IsActive));

        [HttpPost]
        [Route("updateUserAdmin")]
        [Authorize("admin")]
        public async Task<IActionResult> UpdateUserAdmin([FromBody] UserSimpleDto user)
        {
            var pUser = await _repository.GetOneAsync<User>(x => x.Id == user.Id);
            var pCustomer = await _customerRepository.GetOneAsync<Customer>(x => x.Id == pUser.CustomerId);
            pUser.IsActive = user.IsActive;
            pCustomer.IsFeePayed = user.IsFeePayed;

            await _repository.UpdateAsync(pUser);
            await _customerRepository.UpdateAsync(pCustomer);
            return Json(true);
        }

        [HttpPut]
        [Authorize("read:messages")]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            if (user == null && user.Id <= 0)
            {
                return BadRequest();
            }
            return Json(await _repository.UpdateAsync(user));
        }

        [HttpGet("{email}")]
        [Route("resetPassword")]
        public async Task<IActionResult> ResetPassword(string email)
        {
            var user = await _repository
                .GetOneAsync<UserSimpleDto>(x => x.Customer.Email == email);

            if (user == null) return Json(false);

            var token = Guid.NewGuid().ToString();
            var activation = await _userActivationRepository.AddAsync(new UserActivation
            {
                Created = DateTime.Now,
                IsUsed = false,
                UserId = user.Id,
                Token = token,
            });

            _userEmailFactory.ResetPassword(user, activation);

            return Json(true);
        }

        [HttpPost()]
        [Route("resetPassword")]
        public async Task<IActionResult> ResetPasswrd([FromBody] ChangePasswordDto model)
            => Json(await _securityService.ResetPassword(model));
    }
}