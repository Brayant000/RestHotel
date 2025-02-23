using Microsoft.AspNetCore.Mvc;
using RestHotel.Infrastructure.Persistence.Entities;
using RestHotel.Infrastructure.Persistence.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestHotel.API.Controllers
{
    [ApiController]
    [Route("api/services")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Service>> GetAll() => await _serviceRepository.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetById(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            return service == null ? NotFound() : Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            try
            {
                await _serviceRepository.AddAsync(service);
                return CreatedAtAction(nameof(GetById), new { id = service.Id }, service);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el servicio", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Service service)
        {
            if (id != service.Id) return BadRequest();
            await _serviceRepository.UpdateAsync(service);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            if (service == null) return NotFound();
            await _serviceRepository.DeleteAsync(service);
            return NoContent();
        }
    }
}