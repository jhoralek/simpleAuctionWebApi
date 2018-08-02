using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;
using System.Threading.Tasks;

namespace SA.WebApi.Controllers
{
    [Route("api/Files")]
    public class FilesController : BaseController<File>
    {
        public FilesController(IEntityRepository<File> repository)
            : base(repository) { }   
    }
}