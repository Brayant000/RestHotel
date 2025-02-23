using Microsoft.AspNetCore.Mvc;
using RestHotel.Infrastructure.Persistence.Entities;
using RestHotel.Infrastructure.Persistence.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestHotel.API.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Room>> GetAll() => await _roomRepository.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetById(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            return room == null ? NotFound() : Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Room room)
        {
            try
            {
                await _roomRepository.AddAsync(room);
                return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear la habitación", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Room room)
        {
            if (id != room.Id) return BadRequest();
            await _roomRepository.UpdateAsync(room);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null) return NotFound();
            await _roomRepository.DeleteAsync(room);
            return NoContent();
        }
    }
}