using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SA.EntityFramework.EntityFramework.Repository
{
    public interface IEntityRepository<T>
    {
        Task AddAsync(T item);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> query = null);
        Task<IEnumerable<T>> GetAllSimpleAsync(Expression<Func<T, bool>> query = null);
        Task<T> GetOneAsync(Expression<Func<T, bool>> query);
        Task<IEnumerable<T>> FindAsync(string key);
        Task<T> GetByIdAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id, T item);
        IQueryable<T> GetAllInternal();
        Task<IEnumerable<TResult>> GetAllProjectToAsync<TResult>(Expression<Func<T, bool>> query = null) where TResult : class;
    }
}
