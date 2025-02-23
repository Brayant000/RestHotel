using Microsoft.EntityFrameworkCore;
using RestHotel.Infrastructure.Persistence.Context;
using RestHotel.Infrastructure.Persistence.Entities;
using RestHotel.Infrastructure.Persistence.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestHotel.Infrastructure.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly HotelContext _context;

        public ServiceRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllAsync() => await _context.Services.ToListAsync();

        public async Task<Service> GetByIdAsync(int id) => await _context.Services.FindAsync(id);

        public async Task AddAsync(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Service service)
        {
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }
    }
}