using Microsoft.AspNetCore.Mvc;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.Api.Controllers
{
    public class BaseController<T> : Controller
    {
        protected IEntityRepository<T> _repository { get; set; }

        public BaseController(IEntityRepository<T> repository)
        {
            _repository = repository;
        }
    }
}
