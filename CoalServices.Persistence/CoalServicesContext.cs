using CoalServices.Carousel.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CoalServices.Carousel.Persistence
{
    public class CoalServicesContext : DbContext
    {
        #region Fields
        #endregion Fields

        #region Properties
        public DbSet<Entities.Image> Images { get; set; }
        #endregion Properties

        #region Constructors
        public CoalServicesContext(DbContextOptions<CoalServicesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion Constructors

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ApplyConfiguration(new ImageEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
