using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;
using System.Threading.Tasks;

namespace SA.WebApi.Controllers
{
    [Route("api/Addresses")]
    public class AddressesController : BaseController<Address>
    {
        public AddressesController(IEntityRepository<Address> repository)
            : base(repository) { }

        [Authorize("read:messages")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Address address)
        {
            if (address == null && address.Id <= 0)
            {
                return BadRequest();
            }
            return Json(await _repository.UpdateAsync(address));
        }
    }
}