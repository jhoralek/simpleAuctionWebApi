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
    public class BidsRepository : IEntityRepository<Bid>
    {
        private readonly SaDbContext _context;
        public BidsRepository(SaDbContext context)
        {
            _context = context;
        }

        public async Task<Bid> AddAsync(Bid item)
        {
            item.Created = DateTime.Now;
            var added = await _context.Bids.AddAsync(item);
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<Bid> RemoveAsync(int id)
        {
            var itemToDelte = await _context.Bids
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelte != null)
            {
                var deleted = _context.Bids.Remove(itemToDelte);
                await _context.SaveChangesAsync();
                return deleted.Entity;
            }
            return null;
        }

        public async Task<Bid> UpdateAsync(Bid item)
        {
            var itemToUpdate = await _context.Bids
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
            Expression<Func<Bid, bool>> query = null,
            Expression<Func<Bid, TOrder>> order = null)
        where TResult : class
        {
            var request = query != null
                ? GetAllBidInternal().Where(query)
                : GetAllBidInternal();

            request = order != null
                ? request.OrderBy(order)
                : request;

            return await request.ProjectTo<TResult>().ToListAsync();
        }

        public async Task<TResult> GetOneAsync<TResult>(Expression<Func<Bid, bool>> query)
            where TResult : class
            => await GetAllBidInternal().Where(query)
                    .ProjectTo<TResult>()
                    .FirstOrDefaultAsync();

        private IQueryable<Bid> GetAllBidInternal()
            => _context.Bids
                .Include(x => x.Record)
                .Include(x => x.Record.Customer)
                .Include(x => x.Record.Customer.Address)
                .Include(x => x.Record.Customer.Address.Country)
                .Include(x => x.User)
                .Include(x => x.User.Customer)
                .Include(x => x.User.Customer.Address)
                .Include(x => x.User.Customer.Address.Country);
    }
}
