using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.Api.Controllers
{
    [Route("api/Countries")]
    public class CountriesController : Controller
    {
        private IEntityRepository<Country> _repository { get; set; }

        public CountriesController(IEntityRepository<Country> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repository.GetAll());

        [HttpGet("{name}", Name = "FindCountries")]
        public async Task<IActionResult> FindByName(string name)
        {
            var items = await _repository.Find(name);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Country item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await _repository.Update(id, item);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Country item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            await _repository.Add(item);
            return CreatedAtRoute("FindCountries", new { Controller = "Countries", name = item.Name }, item);
        }
    }
}