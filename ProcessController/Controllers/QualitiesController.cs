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
    public class QualitiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Quality> _qualityRepository;

        public QualitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _qualityRepository = new QualityRepository(_unitOfWork);
        }

        // GET: api/Qualities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quality>>> GetQualities()
        {
            return await _qualityRepository.Get();
        }

        // GET: api/Qualities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quality>> GetQuality(int id)
        {
            var quality = await _qualityRepository.GetById(id);

            if (quality == null)
            {
                return NotFound();
            }

            return quality;
        }

        // PUT: api/Qualities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuality(int id, Quality quality)
        {
            if (id != quality.Id)
            {
                return BadRequest();
            }

            await _qualityRepository.Update(id, quality);

            return NoContent();
        }

        // POST: api/Qualities
        [HttpPost]
        public async Task<ActionResult<Quality>> CreateQuality(Quality quality)
        {
            await _qualityRepository.Create(quality);

            return CreatedAtAction("GetQuality", new { id = quality.Id }, quality);
        }

        // DELETE: api/Qualities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuality(int id)
        {
            await _qualityRepository.Delete(id);

            return NoContent();
        }
    }
}
