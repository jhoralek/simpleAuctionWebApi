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

        public async Task AddAsync(User item)
        {
            item.Created = DateTime.Now;
            await _context.Users.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> FindAsync(string key)
            => await GetAllAsync(x => x.UserName.StartsWith(key));            

        public async Task<User> GetByIdAsync(int id)
            => await GetAllInternal().FirstOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(int id)
        {
            var itemToDelte = await GetAllInternal()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelte != null)
            {
                _context.Remove(itemToDelte);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(int id, User item)
        {
            var itemToUpdate = await GetAllInternal()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToUpdate != null)
            {
                itemToUpdate.UserName = item.UserName;
                itemToUpdate.Language = item.Language;
                itemToUpdate.SendingNews = item.SendingNews;

                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<User> GetAllInternal()
            => _context.Users.AsQueryable();

        public IQueryable<User> GetAllUserInternal()
            => _context.Users
                .Include(x => x.Customer)
                .Include(x => x.Customer.Address)
                .Include(x => x.Customer.Address.Country);

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> query = null)
             => await
                (query != null
                    ? GetAllUserInternal().Where(query)
                    : GetAllUserInternal())
                .ToListAsync();

        public Task<User> GetOneAsync(Expression<Func<User, bool>> query)
            => GetAllUserInternal().FirstOrDefaultAsync(query);

        public async Task<IEnumerable<User>> GetAllSimpleAsync(Expression<Func<User, bool>> query = null)
           => await(query != null
                        ? GetAllInternal().Where(query)
                        : GetAllInternal())
                    .ToListAsync();
    }
}
