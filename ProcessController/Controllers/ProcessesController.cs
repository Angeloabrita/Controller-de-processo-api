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
    public class ProcessesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProcessesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Processes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Process>>> GetProcesses()
        {
            // Retrieve a list of all processes
            return await _context.Processs.ToListAsync();
        }

        // GET: api/Processes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Process>> GetProcess(int id)
        {
            // Retrieve a specific process by ID
            var process = await _context.Processs.FindAsync(id);

            if (process == null)
            {
                // Return 404 if the process is not found
                return NotFound();
            }

            return process;
        }

        // POST: api/Processes
        [HttpPost]
        public async Task<ActionResult<Process>> CreateProcess(Process process)
        {
            // Add a new process to the database
            _context.Processs.Add(process);
            await _context.SaveChangesAsync();

            // Return 201 Created status along with the created process
            return CreatedAtAction(nameof(GetProcess), new { id = process.Id }, process);
        }

        // PUT: api/Processes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProcess(int id, Process process)
        {
            if (id != process.Id)
            {
                // Return 400 Bad Request if the provided ID doesn't match the model's ID
                return BadRequest();
            }

            // Mark the process as modified and update the database
            _context.Entry(process).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessExists(id))
                {
                    // Return 404 Not Found if the process doesn't exist
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

        // DELETE: api/Processes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcess(int id)
        {
            var process = await _context.Processs.FindAsync(id);
            if (process == null)
            {
                // Return 404 Not Found if the process doesn't exist
                return NotFound();
            }

            // Remove the process from the database and update
            _context.Processs.Remove(process);
            await _context.SaveChangesAsync();

            // Return 204 No Content status
            return NoContent();
        }

        private bool ProcessExists(int id)
        {
            // Check if a process with the given ID exists
            return _context.Processs.Any(e => e.Id == id);
        }
    }
}
