using EGID.Test.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EGID.Test.API.Data
{
    public class EGIDDbContext:DbContext
    {
        public EGIDDbContext(DbContextOptions<EGIDDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder
            //    .ApplyConfiguration(new DepartmentConfiguration());

            //builder
            //    .ApplyConfiguration(new StockConfiguration());

            ModelBuilderExtensions.Seed(builder);
        }

        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Person> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Broker> Brokers { get; set; }
    }
}
