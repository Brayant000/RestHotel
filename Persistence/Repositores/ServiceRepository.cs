using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Servicios;
using RestHotel.Infrastructure.Persistence.Context;
using RestHotel.Infrastructure.Persistence.Interfaces;

namespace RestHotel.Infrastructure.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly HotelContext _context;

        public ServiceRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Servicio>> GetAllServicesAsync()
        {
            return await _context.Servicios.ToListAsync();
        }

        public async Task<Servicio> GetServiceByIdAsync(int id)
        {
            return await _context.Servicios.FindAsync(id);
        }

        public async Task AddServiceAsync(Servicio servicio)
        {
            await _context.Servicios.AddAsync(servicio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceAsync(Servicio servicio)
        {
            _context.Servicios.Update(servicio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
                await _context.SaveChangesAsync();
            }
        }
    }
}