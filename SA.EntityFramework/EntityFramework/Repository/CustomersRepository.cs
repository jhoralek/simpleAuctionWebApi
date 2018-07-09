using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Add(Customer item)
        {
            item.Created = DateTime.Now;
            await _context.Customers.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> Find(string key)
            => await GetCustomersInternal()
                .Where(x => x.Email.StartsWith(key))
                .ToListAsync();

        public async Task<IEnumerable<Customer>> GetAll()
            => await GetCustomersInternal().ToListAsync();

        public async Task<Customer> GetById(int id)
            => await GetCustomersInternal().FirstOrDefaultAsync(x => x.Id == id);

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

        public async Task Update(int id, Customer item)
        {
            var itemToUpdate = await GetQueryAll()
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

        public IQueryable<Customer> GetQueryAll()
            => _context.Customers.AsQueryable();

        private IQueryable<Customer> GetCustomersInternal()
            => GetQueryAll()
                .Include(x => x.Address)
                .Include(x => x.Address.Country)
                .Include(x => x.Records);
    }
}
