using SGA.Domain.Entities.Servicios;

namespace RestHotel.Infrastructure.Persistence.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Servicio>> GetAllServicesAsync();
        Task<Servicio> GetServiceByIdAsync(int id);
        Task AddServiceAsync(Servicio servicio);
        Task UpdateServiceAsync(Servicio servicio);
        Task DeleteServiceAsync(int id);
    }
}