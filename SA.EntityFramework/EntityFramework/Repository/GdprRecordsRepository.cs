using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SA.Core.Model;

namespace SA.EntityFramework.EntityFramework.Repository
{
    public class GdprRecordsRepository : IEntityRepository<GdprRecord>
    {
        private readonly SaDbContext _context;
        public SaDbContext Context { get { return _context; } }
        public GdprRecordsRepository(SaDbContext context)
        {
            _context = context;
        }

        public async Task<GdprRecord> AddAsync(GdprRecord item)
        {
            item.Created = DateTime.Now;
            var added = await _context.GdprRecords.AddAsync(item);
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public Task<GdprRecord> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GdprRecord> UpdateAsync(GdprRecord item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult, TOrder>(
            Expression<Func<GdprRecord, bool>> query = null,
            Expression<Func<GdprRecord, TOrder>> order = null,
            int? take = null)
            where TResult : class
        {
            var request = query != null
                ? _context.GdprRecords.Where(query)
                : _context.GdprRecords;

            request = order != null
                ? request.OrderBy(order)
                : request;

            return await request.ProjectTo<TResult>().ToListAsync();
        }

        public async Task<TResult> GetOneAsync<TResult>(Expression<Func<GdprRecord, bool>> query)
            where TResult : class
            => await _context.GdprRecords.Where(query)
                .ProjectTo<TResult>()
                .FirstOrDefaultAsync();
    }
}
