using Microsoft.EntityFrameworkCore;

namespace Journal.Experimental;

public abstract class GenericRepository<T> where T : class
{
    protected DbSet<T> Set { get; }

    public virtual async Task<IEnumerable<T>> GetManyAsync(ISpecification<T> spec)
    {
        throw new NotImplementedException();
    }
    public virtual async Task<IEnumerable<TOut>> GetManyAsync<TOut>(ISpecification<T, TOut> spec)
        where TOut : class
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> GetOneAsync(ISpecification<T> spec)
    {
        throw new NotImplementedException();
    }
    public virtual async Task<TOut> GetOneAsync<TOut>(ISpecification<T, TOut> spec)
        where TOut : class
    {
        throw new NotImplementedException();
    }

    public virtual async Task PutAsync(ISpecification<T> spec, T entity)
    {
        throw new NotImplementedException();
    }
    public virtual async Task DeleteAsync(ISpecification<T> spec)
    {
        throw new NotImplementedException();
    }
    public virtual async Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }


    protected IQueryable<T> ApplySpecification(
        IQueryable<T> query,
        ISpecification<T> spec)
    {
        query = spec.ApplyJoining(query);
        query = spec.ApplyFiltering(query);
        return spec.ApplyOrdering(query);
    }

    protected IQueryable<TOut> ApplySpecification<TOut>(
        IQueryable<T> query,
        ISpecification<T, TOut> spec)
        where TOut : class
    {
        query = ApplySpecification(query, spec as ISpecification<T>);
        return spec.ApplyMapping(query);
    }
}
