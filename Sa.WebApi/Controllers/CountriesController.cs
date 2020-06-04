using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Application.Country;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.WebApi.Controllers
{
    [Route("api/Countries")]
    public class CountriesController : BaseController<Country>
    {
        public CountriesController(IEntityRepository<Country> repository)
            : base(repository) { }

        [Authorize("read:messages")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _repository.GetAllAsync<CountryDto, string>(orderAsc: x => x.Name);
            return Json(countries);
        }
    }
}