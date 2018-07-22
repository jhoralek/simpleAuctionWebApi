using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task AddAsync(Country item)
        {
            item.Created = DateTime.Now;
            await _context.Countries.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> FindAsync(string key)
            => await GetAllAsync(x => x.Name.StartsWith(key));

        public async Task<IEnumerable<Country>> GetAll()
            => await GetAllInternal().ToListAsync();

        public async Task<Country> GetByIdAsync(int id)
            => await GetAllInternal()
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

        public IQueryable<Country> GetAllInternal()
            => _context.Countries.AsQueryable();

        public async Task UpdateAsync(int id, Country item)
        {
            var itemToUpdate = await GetAllInternal()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Language = item.Language;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Country>> GetAllAsync(Expression<Func<Country, bool>> query = null)
            => await
                (query != null
                    ? GetAllInternal().Where(query)
                    : GetAllInternal())
                .ToListAsync();

        public Task<Country> GetOneAsync(Expression<Func<Country, bool>> query)
            => GetAllInternal().FirstOrDefaultAsync(query);

        public async Task<IEnumerable<Country>> GetAllSimpleAsync(Expression<Func<Country, bool>> query = null)
           => await GetAllAsync(query);
    }
}
