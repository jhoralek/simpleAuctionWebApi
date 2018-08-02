using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.WebApi.Controllers
{
    [Route("api/Users")]
    public class UsersController : BaseController<User>
    {
        public UsersController(IEntityRepository<User> repository)
            : base(repository) { }

        [Authorize("read:messages")]
        [Route("LoadByNameAndToken")]
        [HttpGet("{uName}/{token}")]
        public async Task<IActionResult> LoadByNameAndToken(string uName, string token)
            => Json(await _repository.GetOneAsync<User>(x => x.UserName == uName
                && x.Token == token));
    }
}