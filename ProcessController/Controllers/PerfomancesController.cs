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
    public class PerfomancesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Perfomance> _performanceRepository;

        public PerfomancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _performanceRepository = new PerfomanceRepository(_unitOfWork);
        }

        // GET: api/Perfomances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfomance>>> GetPerfomances()
        {
            return await _performanceRepository.Get();
        }

        // GET: api/Perfomances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfomance>> GetPerformance(int id)
        {
            var performance = await _performanceRepository.GetById(id);

            if (performance == null)
            {
                return NotFound();
            }

            return performance;
        }

        // PUT: api/Perfomances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerformance(int id, Perfomance performance)
        {
            if (id != performance.Id)
            {
                return BadRequest();
            }

            await _performanceRepository.Update(id, performance);

            return NoContent();
        }

        // POST: api/Perfomances
        [HttpPost]
        public async Task<ActionResult<Perfomance>> CreatePerformance(Perfomance performance)
        {
            await _performanceRepository.Create(performance);

            return CreatedAtAction("GetPerformance", new { id = performance.Id }, performance);
        }

        // DELETE: api/Perfomances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformance(int id)
        {
            await _performanceRepository.Delete(id);

            return NoContent();
        }
    }
}
