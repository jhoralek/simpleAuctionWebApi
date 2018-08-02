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
    public class AddressesRepository : IEntityRepository<Address>
    {
        private readonly SaDbContext _context;
        public AddressesRepository(SaDbContext context)
        {
            _context = context;
        }

        public async Task<Address> AddAsync(Address item)
        {
            item.Created = DateTime.Now;
            var added = await _context.Addresses.AddAsync(item);
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<Address> RemoveAsync(int id)
        {
            var itemToDelte = await _context.Addresses
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelte != null)
            {
                var deleted = _context.Addresses.Remove(itemToDelte);
                await _context.SaveChangesAsync();
                return deleted.Entity;
            }
            return null;
        }

        public async Task<Address> UpdateAsync(Address item)
        {
            var itemToUpdate = await _context.Addresses
                .FirstOrDefaultAsync(x => x.Id == item.Id);

            if (itemToUpdate != null)
            {
                Mapper.Map(item, itemToUpdate);
                await _context.SaveChangesAsync();
                return itemToUpdate;
            }
            return null;
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult, TOrder>(
            Expression<Func<Address, bool>> query = null,
            Expression<Func<Address, TOrder>> order = null)
                where TResult : class
        {
            var request = query != null
                ? GetIncludeAll().Where(query)
                : GetIncludeAll();

            request = order != null
                ? request.OrderBy(order)
                : request;

            return await request.ProjectTo<TResult>().ToListAsync();
        }

        public async Task<TResult> GetOneAsync<TResult>(Expression<Func<Address, bool>> query)
            where TResult : class
            => await GetIncludeAll().Where(query)
                    .ProjectTo<TResult>()
                    .FirstOrDefaultAsync();

        private IQueryable<Address> GetIncludeAll()
            => _context.Addresses.Include(x => x.Country);

    }
}
