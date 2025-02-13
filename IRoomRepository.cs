using System.Collections.Generic;
using RestHotel.Domain.Entities;

namespace RestHotel.Persistence.Interfaces
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int id);
    }
}