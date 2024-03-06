using ProcessController.Data;
using ProcessController.Model;
using ProcessController.Services.IRepository;

namespace ProcessController.Services.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public IAvailabilityRepository? Avaibles { get; private set; }
        public IOeeRepository? Oee {  get;  set; }
        public IPerfomanceRepository? Perfomance { get;  set; }

        public IProcessControlRepository? ProcessControl {  get; set; }

        public IProcessRepository? Process {  get;  set; }

        public IQualityRepository? Quality { get;  set; }

        

        public UnitOfWork(AppDbContext context, ILogger logger, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            

        }

        public async Task CompletAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
