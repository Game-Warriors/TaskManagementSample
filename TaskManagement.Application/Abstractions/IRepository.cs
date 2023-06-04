namespace TaskManagement.Application.Abstractions
{
    public interface IRepository<T, U> where U : class
    {
        Task<U> GetAsync(T id);
        Task<bool> AddAsync(U item);
        Task<bool> DeleteAsync(T id);
        Task<bool> UpdateAsync(U item);
        Task<IList<U>> GetAllAsync();
    }
}
