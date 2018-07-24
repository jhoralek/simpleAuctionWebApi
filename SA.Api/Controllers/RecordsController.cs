
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SA.Application.Records;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.Api.Controllers
{
    [EnableCors("SA")]
    [Route("api/Records")]
    public class RecordsController : BaseController<Record>
    {
        private readonly IRecordService _recordService;
        public RecordsController(
            IEntityRepository<Record> repository,
            IRecordService recordService)
            : base(repository)
        {
            _recordService = recordService;
        }

        [Authorize("read:messages")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
                => Json(await _recordService.GetAll());
        
        [HttpGet]
        [Route("getAllForList")]
        public async Task<IActionResult> GetAllForList()
            => Json(await _recordService.GetAllForList());

        [Route("getById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Json(await _recordService.GetById(id));

        [Authorize("read:messages")]
        [HttpGet("{name}", Name = "FindRecords")]
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
        public async Task<IActionResult> Update(int id, [FromBody] Record item)
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
        public async Task<IActionResult> Create([FromBody] Record item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            await _repository.AddAsync(item);
            return CreatedAtRoute("FindRecords", new { Controller = "Records", name = item.Name }, item);
        }

        [Authorize("read:messages")]
        [HttpGet("{id}")]
        [Route("allActiveWithUsersBids")]
        public ActionResult AllActiveWithUsersBids(int id)
            => Json( _recordService.GetAllForCustomerMinimum(id));
    }
}