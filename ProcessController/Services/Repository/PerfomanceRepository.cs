using ProcessController.Model;
using ProcessController.Services.IRepository;

namespace ProcessController.Services.Repository
{
    public class PerfomanceRepository : Repository<Perfomance>
    {
        public PerfomanceRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { } 
    }
}
