using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Reservas;
using RestHotel.Infrastructure.Persistence.Context;
using RestHotel.Infrastructure.Persistence.Interfaces;

namespace RestHotel.Infrastructure.Persistence.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _context;

        public RoomRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Habitacion>> GetAllRoomsAsync()
        {
            return await _context.Habitaciones.ToListAsync();
        }

        public async Task<Habitacion> GetRoomByIdAsync(int id)
        {
            return await _context.Habitaciones.FindAsync(id);
        }

        public async Task AddRoomAsync(Habitacion habitacion)
        {
            await _context.Habitaciones.AddAsync(habitacion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoomAsync(Habitacion habitacion)
        {
            _context.Habitaciones.Update(habitacion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(int id)
        {
            var habitacion = await _context.Habitaciones.FindAsync(id);
            if (habitacion != null)
            {
                _context.Habitaciones.Remove(habitacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}