using SA.Core.Model;
using System.Linq;

namespace SA.EntityFramework.EntityFramework.Repository
{
    public class GdprRecordsRepository : BaseRepository<GdprRecord>, IEntityRepository<GdprRecord>
    {
        public GdprRecordsRepository(SaDbContext context) : base(context)
        { }

        protected override IQueryable<GdprRecord> GetIncludedAll()
            => _context.GdprRecords;
    }
}
