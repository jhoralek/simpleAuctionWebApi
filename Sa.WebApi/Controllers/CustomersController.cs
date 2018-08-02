using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Application.Customer;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.WebApi.Controllers
{
    [Route("api/Customers")]
    public class CustomersController : BaseController<Customer>
    {
        public CustomersController(IEntityRepository<Customer> repository)
            : base(repository) { }

        [Authorize("read:messages")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Json(await _repository.GetAllAsync<CustomerSimpleDto, string>());
    }
}