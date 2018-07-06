using System.Collections.Generic;
using System.Threading.Tasks;

namespace SA.EntityFramework.EntityFramework.Repository
{
    public interface IEntityRepository<T>
    {
        Task Add(T item);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(string key);
        Task<T> GetById(int id);
        Task Remove(int id);
        Task Update(int id, T item);
    }
}
