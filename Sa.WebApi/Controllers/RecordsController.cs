
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Application.Records;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.WebApi.Controllers
{
    [Route("api/Records")]
    public class RecordsController : BaseController<Record>
    {
        public RecordsController(IEntityRepository<Record> repository) 
            : base(repository){}

        [HttpGet]
        [Route("getAllForList")]
        public async Task<IActionResult> GetAllForList()
            => Json(await _repository
                .GetAllAsync<RecordTableDto, string>(x => 
                    x.IsActive && 
                    x.ValidTo >= DateTime.Now, 
                x => x.Name));

        [Route("getById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Json(await _repository.GetOneAsync<RecordDetailDto>(x => x.Id == id));

        [Authorize("read:messages")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Record item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(item);
            return NoContent();
        }

        [Authorize("read:messages")]
        [HttpGet("{id}")]
        [Route("allActiveWithUsersBids")]
        public ActionResult AllActiveWithUsersBids(int id)
            => Json(_repository.GetAllAsync<RecordMinimumDto, DateTime>(x =>
                    x.Bids.Any() &&
                    x.UserId == id &&
                    x.ValidTo >= DateTime.Now &&
                    x.IsActive,
               x => x.ValidTo));
    }
}