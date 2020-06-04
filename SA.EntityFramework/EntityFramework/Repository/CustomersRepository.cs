using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System.Linq;

namespace SA.EntityFramework.EntityFramework.Repository
{
    public class CustomersRepository : BaseRepository<Customer>, IEntityRepository<Customer>
    {
        public CustomersRepository(SaDbContext context) : base(context)
        { }

        protected override IQueryable<Customer> GetIncludedAll()
            => _context.Customers
                .Include(x => x.Address)
                .Include(x => x.Address.Country);
    }
}
