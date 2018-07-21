using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.Api.Controllers
{
    [EnableCors("SA")]
    [Route("api/Countries")]
    public class CountriesController : BaseController<Country>
    {
        public CountriesController(IEntityRepository<Country> repository) 
            : base(repository) {}

        [Authorize("read:messages")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repository.GetAllAsync());

        [Authorize("read:messages")]
        [HttpGet("{name}", Name = "FindCountries")]
        public async Task<IActionResult> FindByName(string name)
        {
            var items = await _repository.FindAsync(name);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [Authorize("read:messages")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Country item)
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
        public async Task<IActionResult> Create([FromBody] Country item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            await _repository.AddAsync(item);
            return CreatedAtRoute("FindCountries", new { Controller = "Countries", name = item.Name }, item);
        }
    }
}