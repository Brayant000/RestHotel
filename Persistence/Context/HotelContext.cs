using Microsoft.EntityFrameworkCore;
using RestHotel.Infrastructure.Persistence.Entities;

namespace RestHotel.Infrastructure.Persistence.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>()
                .HasIndex(r => r.Name)
                .IsUnique(); // Evita nombres duplicados en habitaciones

            modelBuilder.Entity<Service>()
                .Property(s => s.Cost)
                .HasPrecision(10, 2); // Define precisión decimal
        }
    }
}