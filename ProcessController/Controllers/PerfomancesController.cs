using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessController.Data;
using ProcessController.Model;

namespace ProcessController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfomancesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PerfomancesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Perfomances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfomance>>> GetPerfomances()
        {
            // Retrieve a list of all performances
            return await _context.Perfomance.ToListAsync();
        }

        // GET: api/Perfomances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfomance>> GetPerfomance(int id)
        {
            // Retrieve a specific performance by ID
            var perfomance = await _context.Perfomance.FindAsync(id);

            if (perfomance == null)
            {
                // Return 404 if the performance is not found
                return NotFound();
            }

            return perfomance;
        }

        // POST: api/Perfomances
        [HttpPost]
        public async Task<ActionResult<Perfomance>> CreatePerfomance(Perfomance perfomance)
        {
            // Add a new performance to the database
            _context.Perfomance.Add(perfomance);
            await _context.SaveChangesAsync();

            // Return 201 Created status along with the created performance
            return CreatedAtAction(nameof(GetPerfomance), new { id = perfomance.Id }, perfomance);
        }

        // PUT: api/Perfomances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerfomance(int id, Perfomance perfomance)
        {
            if (id != perfomance.Id)
            {
                // Return 400 Bad Request if the provided ID doesn't match the model's ID
                return BadRequest();
            }

            // Mark the performance as modified and update the database
            _context.Entry(perfomance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfomanceExists(id))
                {
                    // Return 404 Not Found if the performance doesn't exist
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

        // DELETE: api/Perfomances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfomance(int id)
        {
            var perfomance = await _context.Perfomance.FindAsync(id);
            if (perfomance == null)
            {
                // Return 404 Not Found if the performance doesn't exist
                return NotFound();
            }

            // Remove the performance from the database and update
            _context.Perfomance.Remove(perfomance);
            await _context.SaveChangesAsync();

            // Return 204 No Content status
            return NoContent();
        }

        private bool PerfomanceExists(int id)
        {
            // Check if a performance with the given ID exists
            return _context.Perfomance.Any(e => e.Id == id);
        }
    }
}
