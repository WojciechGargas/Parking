using Microsoft.EntityFrameworkCore;

namespace Parking.Entities
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=Parking;Trusted_Connection=True;";

        public DbSet<ParkingSpot>  ParkingLot { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingSpot>()
                .Property(ps => ps.Floor)
                .HasDefaultValue(1);
            modelBuilder.Entity<ParkingSpot>()
                .OwnsOne(ps => ps.Size, size =>
                {
                    size.Property(s => s.Width).HasDefaultValue(3.0).IsRequired();
                    size.Property(s => s.Length).HasDefaultValue(5.0).IsRequired();
                    size.Property(s => s.MaxVehicleHeight).HasDefaultValue(2.2).IsRequired();
                });
            modelBuilder.Entity<ParkingSpot>()
                .Property(ps => ps.Empty)
                .HasDefaultValue(true);
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }

        }
    }
}
