namespace TaskManagement.Application.Abstractions
{
    public interface IRepository<T, U> where U : class
    {
        public Task<U> GetAsync(T id);
        public Task<bool> AddAsync(U item);
        public Task<bool> DeleteAsync(T id);
        public Task<bool> UpdateAsync(U item);
    }
}
