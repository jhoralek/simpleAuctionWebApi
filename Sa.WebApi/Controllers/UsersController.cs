using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Application.Account;
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
        public UsersController(
            IEntityRepository<User> repository,
            ISecurityService securityService,
            IEntityRepository<Customer> customerRepository)
            : base(repository)
        {
            _securityService = securityService;
            _customerRepository = customerRepository;
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
            return Json(await _repository.AddAsync(user));
        }

        [HttpGet]
        [Authorize("admin")]
        [Route("getAllUsersForAdmin")]
        public async Task<IActionResult> GetAllUsersForAdmin()
            => Json(await _repository
                .GetAllAsync<UserSimpleDto, bool>(u =>
                    !u.Customer.IsDealer,
                u => u.IsActive));

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
    }
}