using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Application.Bid;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.WebApi.Controllers
{
    [Route("api/Bids")]
    public class BidsController : BaseController<Bid>
    {
        public BidsController(IEntityRepository<Bid> repository)
            : base(repository) { }

        [Authorize("read:messages")]
        [HttpGet("{recordId}")]
        [Route("getActualPrice")]
        public async Task<IActionResult> GetActualPrice(int recordId)
        {
            var bids = await _repository
                .GetAllAsync<BidSimpleDto, decimal>(x => 
                    x.RecordId == recordId, x => x.Price);
            return Json(bids.Max(x => x.Price));
        }
    }
}