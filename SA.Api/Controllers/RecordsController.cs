using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.Api.Controllers
{
    [Route("api/Records")]
    public class RecordsController : BaseController<Record>
    {
        public RecordsController(IEntityRepository<Record> repository)
            : base(repository) { }

        [Authorize("read:messages")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
                => Ok(await _repository.GetAll());

        [HttpGet("{name}", Name = "FindRecords")]
        public async Task<IActionResult> FindByName(string name)
        {
            var items = await _repository.Find(name);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [Authorize("read:messages")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Record item)
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
        public async Task<IActionResult> Create([FromBody] Record item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            await _repository.Add(item);
            return CreatedAtRoute("FindRecords", new { Controller = "Records", name = item.Name }, item);
        }
    }
}