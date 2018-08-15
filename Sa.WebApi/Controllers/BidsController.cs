using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Application;
using SA.Application.Bid;
using SA.Application.Records;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.WebApi.Controllers
{
    [Route("api/Bids")]
    public class BidsController : BaseController<Bid>
    {
        private readonly IEntityRepository<Record> _recordRepository;
        public BidsController(
            IEntityRepository<Bid> repository,
            IEntityRepository<Record> recordRepository)
            : base(repository)
        {
            _recordRepository = recordRepository;
        }

        [Authorize("read:messages")]
        [HttpGet("{recordId}")]
        [Route("getActualPrice")]
        public async Task<IActionResult> GetActualPrice(int recordId)
        {
            var bids = await _repository
                .GetAllAsync<Application.Bid.BidSimpleDto, decimal>(x => 
                    x.RecordId == recordId, x => x.Price);
            return Json(bids.Max(x => x.Price));
        }

        [Authorize("read:messages")]
        [HttpPost("{recordValidTo}")]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Bid bid)
        {
            var response = new ResponseMessage<Bid>
            {
                Status = MessageStatusEnum.Error,
                Entity = bid,
            };

            var now = DateTime.Now;
            if (bid == null && bid.RecordId <= 0)
            {
                response.Code = "bidBadRequest";
                return Json(response);
            }

            var record = await _recordRepository.GetOneAsync<RecordTableDto>(x => x.Id == bid.RecordId);

            if (record.CurrentPrice >= bid.Price)
            {
                response.Status = MessageStatusEnum.Warning;
                response.Code = "bidOverpaid";
                return Json(response);
            }

            try
            {
                var newBid = await _repository.AddAsync(bid);
                // extend when last bid is less then 5 min. before auction ends.
                if (now.AddMinutes(5) >= record.ValidTo)
                {
                    record.ValidTo = record.ValidTo.AddMinutes(5);
                    await _recordRepository.UpdateAsync(Mapper.Map<Record>(record));
                }

                response.Status = MessageStatusEnum.Success; ;
                response.Code = "createdSuccessfully";
            }
            catch(Exception e)
            {
                response.Status = MessageStatusEnum.Error;
                response.Code = "bidBadRequest";
            }

            return Json(response);
        }
    }
}