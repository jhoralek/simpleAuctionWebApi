using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.Api.Controllers
{
    [EnableCors("SA")]
    [Route("api/Users")]
    public class UsersController : BaseController<User>
    {
        public UsersController(IEntityRepository<User> repository) 
            : base(repository) {}

        [Authorize("read:messages")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repository.GetAllAsync());

        [Authorize("read:messages")]
        [HttpGet("{userName}", Name = "FindUsers")]
        public async Task<IActionResult> FindByUserName(string userName)
        {
            var items = await _repository.FindAsync(userName);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [Authorize("read:messages")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(id, item);
            return NoContent();
        }

        [Authorize("read:messages")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            await _repository.AddAsync(item);
            return CreatedAtRoute("FindUsers", new { Controller = "Users", name = item.UserName }, item);
        }

        [Authorize("read:messages")]
        [Route("LoadByNameAndToken")]
        [HttpGet("{uName}/{token}")]
        public async Task<IActionResult> LoadByNameAndToken(string uName, string token)
            => Json(await _repository.GetOneAsync<User>(x => x.UserName == uName
                && x.Token == token));
    }
}