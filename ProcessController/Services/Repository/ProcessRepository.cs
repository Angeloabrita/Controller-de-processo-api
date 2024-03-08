using ProcessController.Model;
using ProcessController.Services.IRepository;

namespace ProcessController.Services.Repository
{
    public class ProcessRepository : Repository<Process>
    {
       public ProcessRepository(IUnitOfWork unitOfWork) : base(unitOfWork ){ }
    }
}
