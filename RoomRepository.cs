using System.Collections.Generic;
using System.Linq;
using RestHotel.Domain.Entities;
using RestHotel.Persistence.Base;
using RestHotel.Persistence.Context;
using RestHotel.Persistence.Interfaces;

namespace RestHotel.Persistence.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelContext context) : base(context) { }

        public IEnumerable<Room> GetAllRooms() => _context.Rooms.ToList();
        public Room GetRoomById(int id) => _context.Rooms.Find(id);
    }
}