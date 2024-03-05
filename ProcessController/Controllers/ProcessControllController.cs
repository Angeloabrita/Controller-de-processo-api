using Microsoft.AspNetCore.Mvc;
using ProcessController.Data;
using ProcessController.Interfaces;
using ProcessController.Model;
using ProcessController.Repository;

namespace ProcessController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessControlController : ControllerBase
    {
        private readonly IRepository<ProcessControl> _processControlRepository;
        private readonly AppDbContext _context;


        public ProcessControlController(IRepository<ProcessControl> processControlRepository, AppDbContext appDbContext)
        {
            _processControlRepository = processControlRepository;
            _context = appDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var processControls = _processControlRepository.GetAll();
             return Ok(processControls);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var processControl = _processControlRepository.GetById(id);

            if (processControl == null)
            {
                return NotFound();
            }

            return Ok(processControl);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProcessControl processControl)
        {
            if (processControl == null)
            {
                return BadRequest();
            }

            
            _processControlRepository.Add(processControl);

            return CreatedAtAction(nameof(GetById), new { id = processControl.Id }, processControl);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProcessControl processControl)
        {
            if (processControl == null || id != processControl.Id)
            {
                return BadRequest();
            }

            var existingProcessControl = _processControlRepository.GetById(id);

            if (existingProcessControl == null)
            {
                return NotFound();
            }

            _processControlRepository.Update(processControl);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var processControl = _processControlRepository.GetById(id);

            if (processControl == null)
            {
                return NotFound();
            }

            _processControlRepository.Delete(id);

            return NoContent();
        }
    }
}
