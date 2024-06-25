namespace Journal.Data.Repositories.Specifications
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        Task DeleteAsync(ISpecification<T> spec);
        Task<IEnumerable<T>> GetManyAsync();
        Task<IEnumerable<T>> GetManyAsync(ISpecification<T> spec);
        Task<IEnumerable<TOut>> GetManyAsync<TOut>(ISpecification<T, TOut> spec) where TOut : class;
        Task<T?> GetFirstAsync(ISpecification<T> spec);
        Task<TOut?> GetFirstAsync<TOut>(ISpecification<T, TOut> spec) where TOut : class;
        void Update(T entity);
    }
}