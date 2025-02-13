using System.Collections.Generic;
using System.Linq;
using RestHotel.Domain.Entities;
using RestHotel.Persistence.Base;
using RestHotel.Persistence.Context;
using RestHotel.Persistence.Interfaces;

namespace RestHotel.Persistence.Repositories
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(HotelContext context) : base(context) { }

        public IEnumerable<Service> GetAllServices() => _context.Services.ToList();
        public Service GetServiceById(int id) => _context.Services.Find(id);
    }
}