using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Add(Address item)
        {
            item.Created = DateTime.Now;
            await _context.Addresses.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> Find(string key)
            => await GetAllInternal()
                .Where(x => x.Street.StartsWith(key))
                .ToListAsync();

        public async Task<IEnumerable<Address>> GetAll()
            => await GetAllInternal().ToListAsync();

        public async Task<Address> GetById(int id)
            => await GetAllInternal()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task Remove(int id)
        {
            var itemToDelete = await GetQueryAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelete != null)
            {
                _context.Remove(itemToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(int id, Address item)
        {
            var itemToUpdate = await GetQueryAll()
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

        public IQueryable<Address> GetQueryAll()
            => _context.Addresses.AsQueryable();

        private IQueryable<Address> GetAllInternal()
            => GetQueryAll().Include(x => x.Country);
    }
}
