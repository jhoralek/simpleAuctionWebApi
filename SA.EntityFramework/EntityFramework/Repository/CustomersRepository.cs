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
    public class CustomersRepository : IEntityRepository<Customer>
    {
        private readonly SaDbContext _context;
        public CustomersRepository(SaDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddAsync(Customer item)
        {
            item.Created = DateTime.Now;
            var added = await _context.Customers.AddAsync(item);
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<Customer> RemoveAsync(int id)
        {
            var itemToDelte = await _context.Customers
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelte != null)
            {
                var deleted = _context.Remove(itemToDelte);
                await _context.SaveChangesAsync();
                return deleted.Entity;
            }
            return null;
        }

        public async Task<Customer> UpdateAsync(Customer item)
        {
            var itemToUpdate = await _context.Customers
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
            Expression<Func<Customer, bool>> query = null,
            Expression<Func<Customer, TOrder>> order = null,
            int? take = null)
                where TResult : class
        {
            var request = query != null
                ? GetCustomersInternal().Where(query)
                : GetCustomersInternal();

            request = order != null
                ? request.OrderBy(order)
                : request;

            return await request.ProjectTo<TResult>().ToListAsync();
        }

        public async Task<TResult> GetOneAsync<TResult>(Expression<Func<Customer, bool>> query)
            where TResult : class
            => await GetCustomersInternal().Where(query)
                    .ProjectTo<TResult>()
                    .FirstOrDefaultAsync();

        private IQueryable<Customer> GetCustomersInternal()
            => _context.Customers
                .Include(x => x.Address)
                .Include(x => x.Address.Country);
    }
}
