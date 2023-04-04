using Microsoft.EntityFrameworkCore;

namespace WeatherEye.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DustSensor>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<EnvironmentalSensor>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<LightSensor>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<RainSensor>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<UVSensor>()
                .HasKey(x => x.Id);
        }

        public DbSet<DustSensor> DustSensors { get;set; }
        public DbSet<EnvironmentalSensor> EnvironmentalSensors { get; set; }
        public DbSet<LightSensor> LightSensors { get; set; }
        public DbSet<RainSensor> RainSensors { get; set;}
        public DbSet<UVSensor> UVSensors { get; set; }
    }
}
