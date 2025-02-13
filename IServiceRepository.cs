using System.Collections.Generic;
using RestHotel.Domain.Entities;

namespace RestHotel.Persistence.Interfaces
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetAllServices();
        Service GetServiceById(int id);
    }
}