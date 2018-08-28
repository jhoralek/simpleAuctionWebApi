using Microsoft.EntityFrameworkCore;
using SA.Core.Model;

namespace SA.EntityFramework.EntityFramework
{
    public class SaDbContext : DbContext
    {
        public SaDbContext(){}

        public SaDbContext(DbContextOptions<SaDbContext> options) : base(options) {}

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Bid> Bids { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Record> Records { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<GdprRecord> GdprRecords { get; set; }

        public DbSet<UserActivation> UserActivations { get; set; }

        public DbSet<Auction> Auctions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(schema: DbGlobals.SchemaName);
            base.OnModelCreating(builder);
        }
    }
}

