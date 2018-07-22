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

        public async Task AddAsync(Address item)
        {
            item.Created = DateTime.Now;
            await _context.Addresses.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> FindAsync(string key)
            => await GetAllAsync(x => x.Street.StartsWith(key));

        public async Task<Address> GetByIdAsync(int id)
            => await GetAllAddressInternal()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(int id)
        {
            var itemToDelete = await GetAllInternal()
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelete != null)
            {
                _context.Remove(itemToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(int id, Address item)
        {
            var itemToUpdate = await GetAllInternal()
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToUpdate != null)
            {
                itemToUpdate.Street = item.Street;
                itemToUpdate.City = item.City;
                itemToUpdate.PostCode = item.PostCode;
                itemToUpdate.CountryId = item.CountryId;

                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<Address> GetAllInternal()
            => _context.Addresses.AsQueryable();

        public async Task<IEnumerable<Address>> GetAllAsync(Expression<Func<Address, bool>> query = null)
        => await 
            (query != null 
                ? GetAllAddressInternal().Where(query)
                : GetAllAddressInternal())
            .ToListAsync();

        private IQueryable<Address> GetAllAddressInternal()
            => GetAllInternal().Include(x => x.Country);

        public Task<Address> GetOneAsync(Expression<Func<Address, bool>> query)
            => GetAllAddressInternal().FirstOrDefaultAsync(query);

        public async Task<IEnumerable<Address>> GetAllSimpleAsync(Expression<Func<Address, bool>> query = null)
            => await GetAllAsync(query);
    }
}
