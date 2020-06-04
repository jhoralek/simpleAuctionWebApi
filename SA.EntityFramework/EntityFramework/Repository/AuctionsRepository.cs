using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System.Linq;

namespace SA.EntityFramework.EntityFramework.Repository
{
    public class AuctionsRepository : BaseRepository<Auction>, IEntityRepository<Auction>
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public AuctionsRepository(
            SaDbContext context,
            IHostingEnvironment hostingEnvironment) : base(context)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        protected override IQueryable<Auction> GetIncludedAll()
            => _context.Auctions
                .Include(x => x.Records);
    }
}
