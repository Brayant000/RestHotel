using Microsoft.EntityFrameworkCore;
using RestHotel.Infrastructure.Persistence.Context;
using RestHotel.Infrastructure.Persistence.Entities;
using RestHotel.Infrastructure.Persistence.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestHotel.Infrastructure.Persistence.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _context;

        public RoomRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllAsync() => await _context.Rooms.ToListAsync();

        public async Task<Room> GetByIdAsync(int id) => await _context.Rooms.FindAsync(id);

        public async Task AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Room room)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}