using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessController.Data;
using ProcessController.Model;
using ProcessController.Services;

namespace ProcessController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilitiesController : ControllerBase
    {
        private readonly AppDbContext _context;


        public AvailabilitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Availabilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Availability>>> GetAvailabilities()
        {
            // Retrieve a list of all availabilities
            return await _context.Availability.ToListAsync();
        }

        // GET: api/Availabilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Availability>> GetAvailability(int id)
        {
            // Retrieve a specific availability by ID
            var availability = await _context.Availability.FindAsync(id);

            if (availability == null)
            {
                // Return 404 if the availability is not found
                return NotFound();
            }

            return availability;
        }

        // POST: api/Availabilities
        [HttpPost]
        public async Task<ActionResult<Availability>> CreateAvailability(Availability availability)
        {
            // Add a new availability to the database
            _context.Availability.Add(availability);
            await _context.SaveChangesAsync();

            // Return 201 Created status along with the created availability
            return CreatedAtAction(nameof(GetAvailability), new { id = availability.ID }, availability);
        }

        // PUT: api/Availabilities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAvailability(int id, Availability availability)
        {
            if (id != availability.ID)
            {
                // Return 400 Bad Request if the provided ID doesn't match the model's ID
                return BadRequest();
            }

            // Mark the availability as modified and update the database
            _context.Entry(availability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailabilityExists(id))
                {
                    // Return 404 Not Found if the availability doesn't exist
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Return 204 No Content status
            return NoContent();
        }

        // DELETE: api/Availabilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvailability(int id)
        {
            var availability = await _context.Availability.FindAsync(id);
            if (availability == null)
            {
                // Return 404 Not Found if the availability doesn't exist
                return NotFound();
            }

            // Remove the availability from the database and update
            _context.Availability.Remove(availability);
            await _context.SaveChangesAsync();

            // Return 204 No Content status
            return NoContent();
        }

        private bool AvailabilityExists(int id)
        {
            // Check if an availability with the given ID exists
            return _context.Availability.Any(e => e.ID == id);
        }
    }
}
