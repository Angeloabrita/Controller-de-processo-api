using ProcessController.Model;
using ProcessController.Services.IRepository;

namespace ProcessController.Services.Repository
{
    public class OeeRepository : Repository<Oee>
    {
        public OeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }    
    }
}
