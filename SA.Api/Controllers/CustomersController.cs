using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.Api.Controllers
{
    [Route("api/Customers")]
    public class CustomersController : BaseController<Customer>
    {
        public CustomersController(IEntityRepository<Customer> repository) 
            : base(repository) {}

        [Authorize("read:messages")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repository.GetAll());

        [HttpGet("{email}", Name = "FindCustomers")]
        public async Task<IActionResult> FindByEmail(string email)
        {
            var items = await _repository.Find(email);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [Authorize("read:messages")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Customer item)
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
        public async Task<IActionResult> Create([FromBody] Customer item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            await _repository.Add(item);
            return CreatedAtRoute("FindCustomers", new { Controller = "Customers", name = item.Email }, item);
        }
    }
}