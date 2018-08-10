
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
            : base(repository) { }

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
        public async Task<IActionResult> AllActiveWithUsersBids(int id)
        {
            var now = DateTime.Now;
            var result = await _repository.GetAllAsync<RecordMinimumDto, DateTime>(x =>
                    x.Bids.Any(y => y.UserId == id) &&
                    x.IsActive &&
                    x.ValidTo >= now,
               x => x.ValidTo);

            return Json(result);
        }

        [Authorize("admin")]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Record record)
            => Json(await _repository.AddAsync(record));
        

        [Authorize("admin")]
        [HttpGet]
        [Route("getAllForAdmin")]
        public async Task<IActionResult> GetAllForAdmin()
            => Json(await _repository
                    .GetAllAsync<RecordTableDto, bool>(order: y =>
                        y.IsActive));
    }
}