﻿using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SA.EntityFramework.EntityFramework.Repository
{
    public class RecordsRepository : IEntityRepository<Record>
    {
        private readonly SaDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public RecordsRepository(
            SaDbContext context,            
            IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<Record> AddAsync(Record item)
        {
            item.Created = DateTime.Now;
            var added = await _context.Records.AddAsync(item);
            await _context.SaveChangesAsync();

            if (added.Entity.Files.Any())
            {
                var root = _hostingEnvironment.WebRootPath;
                foreach (var file in added.Entity.Files)
                {
                    var tempFullPath = Path.Combine(root, $"tempFiles/{file.Name}");
                    var targetPath = Path.Combine(root, $"{file.Path}/{file.RecordId}/images/");
                    var destFullPath = Path.Combine(targetPath, file.Name);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    System.IO.File.Copy(tempFullPath, destFullPath, true);
                }
            }

            return added.Entity;
        }

        public async Task<Record> RemoveAsync(int id)
        {
            var itemToDelte = await _context.Records
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelte != null)
            {
                var deleted = _context.Records.Remove(itemToDelte);
                await _context.SaveChangesAsync();
                return deleted.Entity;
            }
            return null;
        }

        public async Task<Record> UpdateAsync(Record item)
        {
            var itemToUpdate = await _context.Records
                .FirstOrDefaultAsync(x => x.Id == item.Id);

            if (itemToUpdate != null)
            {
                Mapper.Map(item, itemToUpdate);
                await _context.SaveChangesAsync();
                return itemToUpdate;
            }
            return null;
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult, TOrder>(
            Expression<Func<Record, bool>> query = null,
            Expression<Func<Record, TOrder>> order = null)
                where TResult : class
        {
            var request = query != null
                ? GetIncludedAll().Where(query)
                : GetIncludedAll();

            request = order != null
                ? request.OrderBy(order)
                : request;

            return await request.ProjectTo<TResult>().ToListAsync();
        }

        public async Task<TResult> GetOneAsync<TResult>(Expression<Func<Record, bool>> query)
            where TResult : class
            => await GetIncludedAll().Where(query)
                    .ProjectTo<TResult>()
                    .FirstOrDefaultAsync();

        private IQueryable<Record> GetIncludedAll()
            => _context.Records
                .Include(x => x.User)
                .Include(x => x.Customer)
                .Include(x => x.Bids)
                .Include(x => x.Files);
    }
}
