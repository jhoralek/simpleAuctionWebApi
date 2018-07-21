using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task AddAsync(File item)
        {
            item.Created = DateTime.Now;
            await _context.Files.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<File>> FindAsync(string key)
            => await GetAllAsync(x => x.Name.StartsWith(key));

        public async Task<File> GetByIdAsync(int id)
            => await GetAllInternal()
                .Include(x => x.Record)
                .Include(x => x.User)
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

        public IQueryable<File> GetAllInternal()
            => _context.Files.AsQueryable();

        public async Task UpdateAsync(int id, File item)
        {
            var itemToUpdate = await GetAllInternal()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Path = item.Path;
                itemToUpdate.RecordId = item.RecordId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<File>> GetAllAsync(Expression<Func<File, bool>> query = null)
            => await
                (query != null
                    ? GetAllInternal().Where(query)
                    : GetAllInternal())
                .ToListAsync();

        public Task<File> GetOneAsync(Expression<Func<File, bool>> query)
            => GetAllInternal().FirstOrDefaultAsync(query);
    }
}
