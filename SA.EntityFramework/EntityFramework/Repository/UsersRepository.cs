using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Add(User item)
        {
            item.Created = DateTime.Now;
            await _context.Users.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> Find(string key)
            => await GetAllInternal()
                .Where(x => x.UserName.StartsWith(key))
                .ToListAsync();

        public async Task<IEnumerable<User>> GetAll()
            => await GetAllInternal().ToListAsync();

        public async Task<User> GetById(int id)
            => await GetAllInternal().FirstOrDefaultAsync(x => x.Id == id);

        public async Task Remove(int id)
        {
            var itemToDelte = await GetQueryAll()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelte != null)
            {
                _context.Remove(itemToDelte);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(int id, User item)
        {
            var itemToUpdate = await GetQueryAll()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToUpdate != null)
            {
                itemToUpdate.UserName = item.UserName;
                itemToUpdate.Language = item.Language;
                itemToUpdate.SendingNews = item.SendingNews;

                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<User> GetQueryAll()
            => _context.Users.AsQueryable();

        public IQueryable<User> GetAllInternal()
            => _context.Users
                .Include(x => x.Bids)
                .Include(x => x.Customer)
                .Include(x => x.Customer.Address)
                .Include(x => x.Customer.Address.Country)
                .Include(x => x.Records);
    }
}
