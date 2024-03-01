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
    public class QualitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QualitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Qualities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quality>>> GetQualities()
        {
            // Retrieve a list of all qualities
            return await _context.Quality.ToListAsync();
        }

        // GET: api/Qualities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quality>> GetQuality(int id)
        {
            // Retrieve a specific quality by ID
            var quality = await _context.Quality.FindAsync(id);

            if (quality == null)
            {
                // Return 404 if the quality is not found
                return NotFound();
            }

            return quality;
        }

        // POST: api/Qualities
        [HttpPost]
        public async Task<ActionResult<Quality>> CreateQuality(Quality quality)
        {

            // Add a new quality to the database
            _context.Quality.Add(quality);
            await _context.SaveChangesAsync();

            // Return 201 Created status along with the created quality
            return CreatedAtAction(nameof(GetQuality), new { id = quality.Id }, quality);
        }

        // PUT: api/Qualities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuality(int id, Quality quality)
        {   
            if (id != quality.Id)
            {
                // Return 400 Bad Request if the provided ID doesn't match the model's ID
                return BadRequest();
            }

            // Mark the quality as modified and update the database
            _context.Entry(quality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QualityExists(id))
                {
                    // Return 404 Not Found if the quality doesn't exist
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

        // DELETE: api/Qualities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuality(int id)
        {
            var quality = await _context.Quality.FindAsync(id);
            if (quality == null)
            {
                // Return 404 Not Found if the quality doesn't exist
                return NotFound();
            }

            // Remove the quality from the database and update
            _context.Quality.Remove(quality);
            await _context.SaveChangesAsync();

            // Return 204 No Content status
            return NoContent();
        }

        private bool QualityExists(int id)
        {
            // Check if a quality with the given ID exists
            return _context.Quality.Any(e => e.Id == id);
        }
    }
}
