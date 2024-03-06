namespace ProcessController.Services.IRepository
{
    public interface IRepository<T> where T : class
    {

        Task<IEnumerable<T>> All(); // Task is a type that represents an asynchronous operation that can return a value
        Task<T> GetById(int id);

        Task<bool> Add(T entity); // returns true if successful

        Task<bool> Delete(int id);

        Task<bool> Upsert(T entity);
    }

}
