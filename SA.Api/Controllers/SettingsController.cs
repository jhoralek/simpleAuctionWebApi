using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SA.Api.Controllers
{
    [Route("api/Settings")]
    [EnableCors("SA")]
    public class SettingsController : Controller
    {
        private readonly IEntityRepository<Country> _countryRepositiory;

        public SettingsController(
            IEntityRepository<Country> countryRepository)
        {
            _countryRepositiory = countryRepository;
        }

        [HttpGet("{lang}")]
        [Route("Countries")]
        public async Task<IActionResult> Countries(string lang)
        {
            var dict = new Dictionary<string, IEnumerable<Country>>();
            var languages = await _countryRepositiory.GetAllAsync(x => x.Language == lang);

            dict.Add(lang, languages);

            return Json(dict);
        }
    }
}
