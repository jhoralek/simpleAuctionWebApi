using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Add(Bid item)
        {
            item.Created = DateTime.Now;
            await _context.Bids.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bid>> Find(string key)
            => await GetBidsInternal()
                .Where(x => x.Equals(key))
                .ToListAsync();

        public async Task<IEnumerable<Bid>> GetAll()
            => await GetBidsInternal().ToListAsync();

        public async Task<Bid> GetById(int id)
            => await GetBidsInternal().FirstOrDefaultAsync(x => x.Id == id);

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

        /// <summary>
        /// It is not possible edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task Update(int id, Bid item)
        {
            Bid itemToUpdate = null;

            if (itemToUpdate != null)
            {
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<Bid> GetQueryAll()
            => _context.Bids.AsQueryable();

        private IQueryable<Bid> GetBidsInternal()
            => GetQueryAll()
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
