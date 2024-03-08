using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessController.Data;
using ProcessController.Model;
using ProcessController.Services.IRepository;

namespace ProcessController.Services.Repository
{
    public abstract class Repository<T> : ControllerBase, IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected DbSet<T> dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfwork)
        {
            _unitOfWork = unitOfwork;
            dbSet = _unitOfWork.Context.Set<T>();
        }

        //Get Request
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var data = await dbSet.ToListAsync();
            return Ok(data);
        }

        //Create Request
        public async Task<ActionResult<T>> Create(T entity)
        {
            dbSet.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        //grt by id
        public async Task<ActionResult<T>> GetById(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        //Update Request
        public async Task<IActionResult> Update(int id, T entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            var existingOrder = await dbSet.FindAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            _unitOfWork.Context.Entry(existingOrder).CurrentValues.SetValues(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        //Delete Request
        public async Task<IActionResult> Delete(int id)
        {
            var data = await dbSet.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            dbSet.Remove(data);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

       
    }
}