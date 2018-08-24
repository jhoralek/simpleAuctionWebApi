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
    public class CountriesRepository : IEntityRepository<Country>
    {
        private readonly SaDbContext _context;
        public CountriesRepository(SaDbContext context)
        {
            _context = context;
        }

        public async Task<Country> AddAsync(Country item)
        {
            item.Created = DateTime.Now;
            var added = await _context.Countries.AddAsync(item);
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<Country> RemoveAsync(int id)
        {
            var itemToDelte = await _context.Countries
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelte != null)
            {
                var deleted = _context.Countries.Remove(itemToDelte);
                await _context.SaveChangesAsync();
                return deleted.Entity;
            }
            return null;
        }

        public async Task<Country> UpdateAsync(Country item)
        {
            var itemToUpdate = await _context.Countries
                .FirstOrDefaultAsync(x => x.Id == item.Id);

            if (itemToUpdate != null)
            {
                Mapper.Map(item, itemToUpdate);
                await _context.SaveChangesAsync();
                return itemToUpdate;
            }
            return null;
        }

        public async Task UpdateAsync(int id, Country item)
        {
            var itemToUpdate = await _context.Countries
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Language = item.Language;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult, TOrder>(
            Expression<Func<Country, bool>> query = null,
            Expression<Func<Country, TOrder>> order = null,
            int? take = null)
                where TResult : class
        {
            var request = query != null
                ? _context.Countries.Where(query)
                : _context.Countries;

            request = order != null
                ? request.OrderBy(order)
                : request;

            return await request.ProjectTo<TResult>().ToListAsync();
        }

        public async Task<TResult> GetOneAsync<TResult>(Expression<Func<Country, bool>> query)
            where TResult : class
            => await _context.Countries.Where(query)
                    .ProjectTo<TResult>()
                    .FirstOrDefaultAsync();

    }
}
