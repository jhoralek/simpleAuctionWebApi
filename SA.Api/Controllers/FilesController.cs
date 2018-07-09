using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;
using System.Threading.Tasks;

namespace SA.Api.Controllers
{
    [Route("api/Files")]
    public class FilesController : BaseController<File>
    {
        public FilesController(IEntityRepository<File> repository) 
            : base(repository) {}

        [Authorize("read:messages")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repository.GetAll());

        [HttpGet("{name}", Name = "FindFiles")]
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
        public async Task<IActionResult> Update(int id, [FromBody] File item)
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
        public async Task<IActionResult> Create([FromBody] File item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            await _repository.Add(item);
            return CreatedAtRoute("FindFiles", new { Controller = "Files", name = item.Name }, item);
        }
    }
}