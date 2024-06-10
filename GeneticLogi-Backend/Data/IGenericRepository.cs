namespace GeneticLogi_Backend.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByNameAsync(string name);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
