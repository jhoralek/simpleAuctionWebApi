using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;

namespace SA.EntityFramework.EntityFramework.Repository
{
    public class AuctionsRepository : IEntityRepository<Auction>
    {
        private readonly SaDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AuctionsRepository(
            SaDbContext context,
            IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<Auction> AddAsync(Auction item)
        {
            item.Created = DateTime.Now;
            var added = await _context.Auctions.AddAsync(item);
            await _context.SaveChangesAsync();            

            return added.Entity;
        }

        public async Task<Auction> RemoveAsync(int id)
        {
            var itemToDelte = await _context.Auctions
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelte != null)
            {
                var deleted = _context.Auctions.Remove(itemToDelte);               

                await _context.SaveChangesAsync();
                return deleted.Entity;
            }
            return null;
        }

        public async Task<Auction> UpdateAsync(Auction item)
        {
            var itemToUpdate = await _context.Auctions
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
            Expression<Func<Auction, bool>> query = null,
            Expression<Func<Auction, TOrder>> order = null,
            int? take = null)
                where TResult : class
        {
            var request = query != null
                ? GetIncludedAll().Where(query)
                : GetIncludedAll();

            request = order != null
                ? request.OrderBy(order)
                : request;

            if (take.HasValue)
            {
                request = request.Take(take.Value);
            }

            return await request.ProjectTo<TResult>().ToListAsync();
        }

        public async Task<TResult> GetOneAsync<TResult>(Expression<Func<Auction, bool>> query)
            where TResult : class
            => await GetIncludedAll().Where(query)
                    .ProjectTo<TResult>()
                    .FirstOrDefaultAsync();

        private IQueryable<Auction> GetIncludedAll()
            => _context.Auctions
                .Include(x => x.Records);
    }
}
