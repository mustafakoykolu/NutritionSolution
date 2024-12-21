namespace Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> QueryAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetPagedAsync(int pageNumber, int pageSize);
        Task<int> GetCountAsync();
    }
}
