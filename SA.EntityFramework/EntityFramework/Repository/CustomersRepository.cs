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

        public async Task AddAsync(Customer item)
        {
            item.Created = DateTime.Now;
            await _context.Customers.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> FindAsync(string key)
            => await GetAllAsync(x => x.Email.StartsWith(key));

        public async Task<Customer> GetByIdAsync(int id)
            => await GetCustomersInternal()
                .FirstOrDefaultAsync(x => x.Id == id);

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

        public async Task UpdateAsync(int id, Customer item)
        {
            var itemToUpdate = await GetAllInternal()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.LastName = item.LastName;
                itemToUpdate.BirthNumber = item.BirthNumber;
                itemToUpdate.TitleBefore = item.TitleBefore;
                itemToUpdate.TitleAfter = item.TitleAfter;
                itemToUpdate.CompanyLegalNumer = item.CompanyLegalNumer;
                itemToUpdate.CompanyNumber = item.CompanyNumber;
                itemToUpdate.PhoneNumber = item.PhoneNumber;
                itemToUpdate.WebPageUrl = item.WebPageUrl;
                itemToUpdate.AddressId = item.AddressId;

                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<Customer> GetAllInternal()
            => _context.Customers.AsQueryable();

        private IQueryable<Customer> GetCustomersInternal()
            => GetAllInternal()
                .Include(x => x.Address)
                .Include(x => x.Address.Country)
                .Include(x => x.Records);

        public async Task<IEnumerable<Customer>> GetAllAsync(Expression<Func<Customer, bool>> query = null)
            => await
                (query != null
                    ? GetCustomersInternal().Where(query)
                    : GetCustomersInternal())
                .ToListAsync();

        public async Task<TResult> GetOneAsync<TResult>(Expression<Func<Customer, bool>> query)
            where TResult : class
            => await GetCustomersInternal().Where(query)
                    .ProjectTo<TResult>()
                    .FirstOrDefaultAsync();

        public async Task<IEnumerable<Customer>> GetAllSimpleAsync(Expression<Func<Customer, bool>> query = null)
           => await (query != null
                        ? GetAllInternal().Where(query)
                        : GetAllInternal())
                    .ToListAsync();

        public async Task<IEnumerable<TResult>> GetAllProjectToAsync<TResult>(Expression<Func<Customer, bool>> query = null) where TResult : class
            => await GetCustomersInternal().Where(query).ProjectTo<TResult>().ToListAsync();
    }
}
