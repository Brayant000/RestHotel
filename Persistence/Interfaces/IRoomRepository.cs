using SGA.Domain.Entities.Reservas;

namespace RestHotel.Infrastructure.Persistence.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Habitacion>> GetAllRoomsAsync();
        Task<Habitacion> GetRoomByIdAsync(int id);
        Task AddRoomAsync(Habitacion habitacion);
        Task UpdateRoomAsync(Habitacion habitacion);
        Task DeleteRoomAsync(int id);
    }
}