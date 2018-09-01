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
            : base(repository) { }

        [HttpGet]
        [Route("getAllForList")]
        public async Task<IActionResult> GetAllForList()
            => Json(await _repository
                .GetAllAsync<RecordTableDto, string>(x =>
                    x.IsActive &&
                    x.ValidTo >= DateTime.Now,
                x => x.Name));

        [HttpGet]
        [Route("getAllCurrentAuctionItems")]
        public async Task<IActionResult> GetAllCurrentAuctionItems()
        {
            var today = DateTime.Now;
            var records = await _repository.GetAllAsync<RecordTableDto, DateTime>(x => x.IsActive
                && x.Auction.IsActive
                && x.Auction.ValidFrom <= today
                && x.Auction.ValidTo >= today
                && !x.Auction.IsEnded
                && x.ValidFrom <= today
                && x.ValidTo >= today,
                x => x.ValidTo);

            return Json(records);
        }

        [Route("getById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _repository.GetOneAsync<RecordDetailDto>(x => x.Id == id);

            if (item != null)
            {
                if (item.Bids.Any())
                {
                    item.Bids = item.Bids.OrderByDescending(x => x.Price).Take(3).ToList();
                }
            }

            return Json(item);
        }
        [Authorize("admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Record record)
        {
            var persistedItem = await _repository.GetOneAsync<Record>(x => x.Id == record.Id);
            if (record == null && persistedItem == null)
            {
                return BadRequest();
            }
            return Json(await _repository.UpdateAsync(record));
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

        [Authorize("admin")]
        [HttpDelete("{id}")]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
            => Json(await _repository.RemoveAsync(id));

        [HttpGet]
        [Route("actualRandom")]
        public async Task<IActionResult> ActualRandom()
        {
            var today = DateTime.Now;

            var items = await _repository
                .GetAllAsync<RecordDetailDto, int>(
                    x =>                    
                        x.IsActive
                        && x.Auction.IsActive
                        && x.Auction.ValidFrom <= today
                        && x.Auction.ValidTo >= today
                        && !x.Auction.IsEnded
                        && x.ValidFrom <= today
                        && x.ValidTo >= today,
                    x => x.Id);

            var randomId = items.Select(x => x.Id).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            var item = items.FirstOrDefault(x => x.Id == randomId);

            if (item != null)
            {
                if (item.Bids.Any())
                {
                    item.Bids = item.Bids.OrderByDescending(x => x.Price).Take(3).ToList();
                }
            }

            return Json(item);
        }
    }
}