using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.Api.Controllers
{
    [Route("api/Users")]
    public class UsersController : BaseController<User>
    {
        public UsersController(IEntityRepository<User> repository) 
            : base(repository) {}

        [Authorize("read:messages")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repository.GetAll());

        [Authorize("read:messages")]
        [HttpGet("{userName}", Name = "FindUsers")]
        public async Task<IActionResult> FindByUserName(string userName)
        {
            var items = await _repository.Find(userName);
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
            await _repository.Update(id, item);
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

            await _repository.Add(item);
            return CreatedAtRoute("FindUsers", new { Controller = "Users", name = item.UserName }, item);
        }
    }
}