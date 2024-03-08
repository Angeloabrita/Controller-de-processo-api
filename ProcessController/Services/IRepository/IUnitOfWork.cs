using Microsoft.EntityFrameworkCore;

namespace ProcessController.Services.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        public Task SaveChangesAsync();
    }
}
