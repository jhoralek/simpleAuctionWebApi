using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.WebApi.Controllers
{
    [Route("api/Addresses")]
    public class AddressesController : BaseController<Address>
    {
        public AddressesController(IEntityRepository<Address> repository)
            : base(repository) { }        
    }
}