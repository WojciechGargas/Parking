using Microsoft.EntityFrameworkCore;

namespace Parking.Entities
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=Parking;Trusted_Connection=True;";

        public DbSet<ParkingSpot>  ParkingLot { get; set; }
        public DbSet<ParkingSpotSize> ParkingSpotSizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingSpotSize>()
                .Property(s => s.Width)
                .IsRequired();
            modelBuilder.Entity<ParkingSpotSize>()
                .Property(s => s.Length)
                .IsRequired();
            modelBuilder.Entity<ParkingSpotSize>()
                .Property(s => s.Width)
                .HasDefaultValue(3.0);
            modelBuilder.Entity<ParkingSpotSize>()
                .Property(s => s.Length)
                .HasDefaultValue(5.0);
            modelBuilder.Entity<ParkingSpotSize>()
                .Property(s => s.MaxVehicleHeight)
                .HasDefaultValue(2.2);
            modelBuilder.Entity<ParkingSpot>()
                .Property(ps => ps.Size)
                .IsRequired();
            modelBuilder.Entity<ParkingSpot>()
                .Property(ps => ps.Empty)
                .HasDefaultValue(true);
            modelBuilder.Entity<ParkingSpot>()
                .Property(ps => ps.Floor)
                .HasDefaultValue(1);
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
