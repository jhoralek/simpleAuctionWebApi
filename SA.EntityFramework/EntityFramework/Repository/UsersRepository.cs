using AutoMapper;
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
    public class UsersRepository : IEntityRepository<User>
    {
        private readonly SaDbContext _context;
        public UsersRepository(SaDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User item)
        {
            item.Created = DateTime.Now;
            try
            {
                var added = await _context.Users.AddAsync(item);
                await _context.SaveChangesAsync();
                return added.Entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> RemoveAsync(int id)
        {
            var itemToDelte = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelte != null)
            {
                var deleted = _context.Users.Remove(itemToDelte);
                await _context.SaveChangesAsync();
                return deleted.Entity;
            }
            return null;
        }

        public async Task<User> UpdateAsync(User item)
        {
            var itemToUpdate = await _context.Users
                .Include(x => x.Records)
                .Include(x => x.Bids)
                .FirstOrDefaultAsync(x => x.Id == item.Id);

            if (itemToUpdate != null)
            {
                itemToUpdate.IsActive = item.IsActive;
                itemToUpdate.SendingNews = item.SendingNews;
                itemToUpdate.Token = item.Token;
                itemToUpdate.Password = item.Password;
                itemToUpdate.Language = item.Language;
                _context.Entry(itemToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return itemToUpdate;
            }
            return null;
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult, TOrder>(
            Expression<Func<User, bool>> query = null,
            Expression<Func<User, TOrder>> order = null,
            int? take = null)
                where TResult : class
        {
            var request = query != null
                ? GetIncludedAll().Where(query)
                : GetIncludedAll();

            request = order != null
                ? request.OrderBy(order)
                : request;

            return await request.ProjectTo<TResult>().ToListAsync();
        }

        public async Task<TResult> GetOneAsync<TResult>(Expression<Func<User, bool>> query)
            where TResult : class
            => await GetIncludedAll().Where(query)
                    .ProjectTo<TResult>()
                    .FirstOrDefaultAsync();

        public IQueryable<User> GetIncludedAll()
            => _context.Users
                .Include(x => x.Customer)
                .Include(x => x.Customer.Address)
                .Include(x => x.Customer.Address.Country);
    }
}
