﻿using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System;
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
            item.Created = DateTime.Now;
            await _context.Countries.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> Find(string key)
            => await GetQueryAll()
                .Where(x => x.Name.StartsWith(key))
                .ToListAsync();

        public async Task<IEnumerable<Country>> GetAll()
            => await GetQueryAll().ToListAsync();

        public async Task<Country> GetById(int id)
            => await GetQueryAll().FirstOrDefaultAsync(x => x.Id == id);

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

        public IQueryable<Country> GetQueryAll()
            => _context.Countries.AsQueryable();

        public async Task Update(int id, Country item)
        {
            var itemToUpdate = await GetQueryAll()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;

                await _context.SaveChangesAsync();
            }
        }
    }
}
