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

        public async Task AddAsync(Bid item)
        {
            item.Created = DateTime.Now;
            await _context.Bids.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bid>> FindAsync(string key)
            => await GetAllAsync(x => x.Equals(key));

        public async Task<Bid> GetByIdAsync(int id)
            => await GetAllBidInternal()
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

        /// <summary>
        /// It is not possible edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task UpdateAsync(int id, Bid item)
        {
            Bid itemToUpdate = null;

            if (itemToUpdate != null)
            {
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<Bid> GetAllInternal()
            => _context.Bids.AsQueryable();

        private IQueryable<Bid> GetAllBidInternal()
            => GetAllInternal()
                .Include(x => x.Record)
                .Include(x => x.Record.Customer)
                .Include(x => x.Record.Customer.Address)
                .Include(x => x.Record.Customer.Address.Country)
                .Include(x => x.User)
                .Include(x => x.User.Customer)
                .Include(x => x.User.Customer.Address)
                .Include(x => x.User.Customer.Address.Country);

        public async Task<IEnumerable<Bid>> GetAllAsync(Expression<Func<Bid, bool>> query = null)
        => await
            (query != null
                ? GetAllBidInternal().Where(query)
                : GetAllBidInternal())
            .ToListAsync();

        public Task<Bid> GetOneAsync(Expression<Func<Bid, bool>> query)
            => GetAllBidInternal().FirstOrDefaultAsync(query);

        public async Task<IEnumerable<Bid>> GetAllSimpleAsync(Expression<Func<Bid, bool>> query = null)
           => await(query != null
                        ? GetAllInternal().Where(query)
                        : GetAllInternal())
                    .ToListAsync();

        public async Task<IEnumerable<TResult>> GetAllProjectToAsync<TResult>(Expression<Func<Bid, bool>> query = null) where TResult : class
            => await GetAllBidInternal().Where(query).ProjectTo<TResult>().ToListAsync();
    }
}
