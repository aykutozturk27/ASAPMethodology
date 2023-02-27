using ASAPMethodology.Core.Utilities.Configuration;
using ASAPMethodology.DataAccess.Concrete.EntityFramework.Mappings;
using ASAPMethodology.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ASAPMethodology.DataAccess.Concrete.EntityFramework.Contexts
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<CostOfFuture> CostOfFutures { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CoreConfig.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CostOfFutureMap());
            modelBuilder.ApplyConfiguration(new ExpenseTypeMap());
        }
    }
}
