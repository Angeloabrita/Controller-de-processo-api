using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessController.Data;
using ProcessController.Model;
using ProcessController.Services;
using ProcessController.Services.IRepository;
using ProcessController.Services.Repository;

namespace ProcessController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilitiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Availability> _availabilityRepository;

        public AvailabilitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _availabilityRepository = new AvailabilityRepository(_unitOfWork);
        }

        // GET: api/Availabilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Availability>>> GetAvailabilities()
        {
            return await _availabilityRepository.Get();
        }

        // GET: api/Availabilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Availability>> GetAvailability(int id)
        {
            var availability = await _availabilityRepository.GetById(id);

            if (availability == null)
            {
                return NotFound();
            }

            return availability;
        }

        // PUT: api/Availabilities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAvailability(int id, Availability availability)
        {
            if (id != availability.Id)
            {
                return BadRequest();
            }

            await _availabilityRepository.Update(id, availability);

            return NoContent();
        }

        // POST: api/Availabilities
        [HttpPost]
        public async Task<ActionResult<Availability>> CreateAvailability(Availability availability)
        {
            await _availabilityRepository.Create(availability);

            return CreatedAtAction("GetAvailability", new { id = availability.Id }, availability);
        }

        // DELETE: api/Availabilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvailability(int id)
        {
            await _availabilityRepository.Delete(id);

            return NoContent();
        }
    }
}
