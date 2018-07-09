using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.Api.Controllers
{
    [Route("api/Addresses")]
    public class AddressesController : BaseController<Address>
    {
        public AddressesController(IEntityRepository<Address> repository) 
            : base(repository) {}

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repository.GetAll());

        [HttpGet("{street}", Name = "FindAddresses")]
        public async Task<IActionResult> FindByName(string street)
        {
            var items = await _repository.Find(street);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Address item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await _repository.Update(id, item);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Address item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            await _repository.Add(item);
            return CreatedAtRoute("FindAddresses", new { Controller = "Addresses", name = item.Street }, item);
        }
    }
}