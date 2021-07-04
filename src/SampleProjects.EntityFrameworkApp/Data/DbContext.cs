using Microsoft.EntityFrameworkCore;
using SampleProjects.EntityFrameworkApp.V1.WeatherForecast;
using Xtz.StronglyTyped.EntityFramework;

namespace SampleProjects.EntityFrameworkApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Register all supported strong types
            modelBuilder.RegisterStronglyTypedConverters();

            base.OnModelCreating(modelBuilder);
        }
    }
}
