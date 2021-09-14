using ABNAmro.Database.ValueConverters;
using ABNAmro.Domain.Calculations;
using ABNAmro.Domain.Progresses;
using Microsoft.EntityFrameworkCore;

namespace ABNAmro.Database
{
    public class ABNAmroContext : DbContext
    {
        public ABNAmroContext(DbContextOptions<ABNAmroContext> options)
            : base(options)
        { }

        public DbSet<Calculation> Calculations { get; set; }

        public DbSet<Progress> Progresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ConfigureCalculation()
                .ConfigureProgress();
        }
    }
}
