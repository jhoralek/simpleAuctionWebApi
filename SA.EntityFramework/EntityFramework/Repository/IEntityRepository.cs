﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;

namespace SA.EntityFramework.EntityFramework.Repository
{
    public interface IEntityRepository<T>
    {
        Task<T> AddAsync(T item);
        Task<T> RemoveAsync(int id);
        Task<T> UpdateAsync(T item);
        Task<IEnumerable<TResult>> GetAllAsync<TResult, TOrder>(
            Expression<Func<T, bool>> query = null,
            Expression<Func<T, TOrder>> orderAsc = null,
            Expression<Func<T, TOrder>> orderDesc = null,
            int? take = null)
                where TResult : class;
        Task<TResult> GetOneAsync<TResult>(Expression<Func<T, bool>> query)
            where TResult : class;

        SaDbContext Context { get; }
    }
}
