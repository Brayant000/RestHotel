using Microsoft.EntityFrameworkCore;
using RestHotel.Domain.Entities;

namespace RestHotel.Persistence.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}