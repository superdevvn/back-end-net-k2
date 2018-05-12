using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TravelManagement.Models.Common
{
    public class TMDbContext:DbContext
    {
        public DbSet<Tour> Tours { get; set; }

        public DbSet<TourDetail> TourDetails { get; set; }

        public TMDbContext()
            : base("Default")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<TMDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
