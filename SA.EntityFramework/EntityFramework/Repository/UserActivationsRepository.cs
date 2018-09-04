using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SA.EntityFramework.EntityFramework.Repository
{
    public class UserActivationsRepository : IEntityRepository<UserActivation>
    {
        private readonly SaDbContext _context;
        public SaDbContext Context { get { return _context; } }
        public UserActivationsRepository(SaDbContext context)
        {
            _context = context;
        }

        public async Task<UserActivation> AddAsync(UserActivation item)
        {
            item.Created = DateTime.Now;
            try
            {
                var added = await _context.UserActivations.AddAsync(item);
                await _context.SaveChangesAsync();
                return added.Entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UserActivation> RemoveAsync(int id)
        {
            var itemToDelte = await _context.UserActivations
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelte != null)
            {
                var deleted = _context.UserActivations.Remove(itemToDelte);
                await _context.SaveChangesAsync();
                return deleted.Entity;
            }
            return null;
        }

        public async Task<UserActivation> UpdateAsync(UserActivation item)
        {
            var itemToUpdate = await _context.UserActivations
                .FirstOrDefaultAsync(x => x.Id == item.Id);

            if (itemToUpdate != null)
            {
                itemToUpdate.IsUsed = item.IsUsed;
                itemToUpdate.Verified = DateTime.Now;

                _context.Entry(itemToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return itemToUpdate;
            }
            return null;
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult, TOrder>(
            Expression<Func<UserActivation, bool>> query = null,
            Expression<Func<UserActivation, TOrder>> order = null,
            int? take = null)
                where TResult : class
        {
            var request = query != null
                ? _context.UserActivations.Where(query)
                : _context.UserActivations;

            request = order != null
                ? request.OrderBy(order)
                : request;

            return await request.ProjectTo<TResult>().ToListAsync();
        }

        public async Task<TResult> GetOneAsync<TResult>(Expression<Func<UserActivation, bool>> query)
            where TResult : class
            => await _context.UserActivations.Where(query)
                    .ProjectTo<TResult>()
                    .FirstOrDefaultAsync();
    }
}
