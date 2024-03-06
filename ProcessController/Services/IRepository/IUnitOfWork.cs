namespace ProcessController.Services.IRepository
{
    public interface IUnitOfWork
    {
        IAvailabilityRepository AvailabilityRepository { get; }
        IOeeRepository OeeRepository { get; }
        IPerfomanceRepository PerfomanceRepository { get; }
        IProcessControlRepository ProcessControlRepository { get; }
        IProcessRepository ProcessRepository { get; }
        
        IQualityRepository QualityRepository { get; }

        Task ConCompleteAsync();
    }
}
