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
    public class OeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Oee> _oeeRepository;

        public OeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _oeeRepository = new OeeRepository(_unitOfWork); // Certifique-se de que OeeRepository implementa IRepository<Oee>
        }

        // GET: api/Oee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oee>>> GetOees()
        {
            return await _oeeRepository.Get();
        }

        // GET: api/Oee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oee>> GetOee(int id)
        {
            var oee = await _oeeRepository.GetById(id);

            if (oee == null)
            {
                return NotFound();
            }

            return oee;
        }

        // PUT: api/Oee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOee(int id, Oee oee)
        {
            if (id != oee.Id)
            {
                return BadRequest();
            }

            await _oeeRepository.Update(id, oee);

            return NoContent();
        }

        // POST: api/Oee
        [HttpPost]
        public async Task<ActionResult<Oee>> CreateOee(Oee oee)
        {
            await _oeeRepository.Create(oee);

            return CreatedAtAction("GetOee", new { id = oee.Id }, oee);
        }

        // DELETE: api/Oee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOee(int id)
        {
            await _oeeRepository.Delete(id);

            return NoContent();
        }
    }
}
