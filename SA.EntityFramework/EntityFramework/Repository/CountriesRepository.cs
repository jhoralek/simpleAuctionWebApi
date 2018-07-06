using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA.EntityFramework.EntityFramework.Repository
{
    public class CountriesRepository : IEntityRepository<Country>
    {
        private readonly SaDbContext _context;
        public CountriesRepository(SaDbContext context)
        {
            _context = context;
        }

        public async Task Add(Country item)
        {
            await _context.Countries.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> Find(string key)
            => await _context.Countries
                .Where(x => x.Name.StartsWith(key))
                .ToListAsync();

        public async Task<IEnumerable<Country>> GetAll()
            => await _context.Countries.ToListAsync();

        public async Task<Country> GetById(int id)
            => await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);

        public async Task Remove(int id)
        {
            var itemToDelte = await _context.Countries
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelte != null)
            {
                _context.Remove(itemToDelte);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(int id, Country item)
        {
            var itemToUpdate = await _context.Countries
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;

                await _context.SaveChangesAsync();
            }
        }
    }
}
