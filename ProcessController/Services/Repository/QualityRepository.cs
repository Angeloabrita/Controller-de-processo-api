using ProcessController.Model;
using ProcessController.Services.IRepository;

namespace ProcessController.Services.Repository
{
    public class QualityRepository : Repository<Quality>
    {
        public QualityRepository(IUnitOfWork unitOfWork) : base(unitOfWork) 
        {

        }
    }
}
