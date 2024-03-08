using ProcessController.Model;
using ProcessController.Services.IRepository;

namespace ProcessController.Services.Repository
{
    public class ProcessControlRepository : Repository<ProcessControl>
    {
        public ProcessControlRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
