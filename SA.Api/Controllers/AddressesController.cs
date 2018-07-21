using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.Api.Controllers
{
    [EnableCors("SA")]
    [Route("api/Addresses")]
    public class AddressesController : BaseController<Address>
    {
        public AddressesController(IEntityRepository<Address> repository) 
            : base(repository) {}

        [Authorize("read:messages")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repository.GetAllAsync());

        [Authorize("read:messages")]
        [HttpGet("{street}", Name = "FindAddresses")]
        public async Task<IActionResult> FindByName(string street)
        {
            var items = await _repository.FindAsync(street);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [Authorize("read:messages")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Address item)
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
        public async Task<IActionResult> Create([FromBody] Address item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            await _repository.AddAsync(item);
            return CreatedAtRoute("FindAddresses", new { Controller = "Addresses", name = item.Street }, item);
        }
    }
}