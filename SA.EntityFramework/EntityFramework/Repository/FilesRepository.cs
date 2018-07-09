using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA.EntityFramework.EntityFramework.Repository
{
    public class FilesRepository : IEntityRepository<File>
    {
        private readonly SaDbContext _context;
        public FilesRepository(SaDbContext context)
        {
            _context = context;
        }

        public async Task Add(File item)
        {
            item.Created = DateTime.Now;
            await _context.Files.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<File>> Find(string key)
            => await GetQueryAll()
                .Where(x => x.Name.StartsWith(key))
                .ToListAsync();

        public async Task<IEnumerable<File>> GetAll()
            => await _context.Files.ToListAsync();

        public async Task<File> GetById(int id)
            => await GetQueryAll()
                .Include(x => x.Record)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

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

        public IQueryable<File> GetQueryAll()
            => _context.Files.AsQueryable();

        public async Task Update(int id, File item)
        {
            var itemToUpdate = await GetQueryAll()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Path = item.Path;
                itemToUpdate.RecordId = item.RecordId;
                await _context.SaveChangesAsync();
            }
        }                
    }
}
