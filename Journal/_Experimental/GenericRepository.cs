using Microsoft.EntityFrameworkCore;

namespace Journal._Experimental;

public abstract class GenericRepository<T> where T : class
{
    protected DbSet<T> Set { get; }

    public virtual async Task<IEnumerable<T>> GetManyAsync() => await Set.ToListAsync();
    public virtual async Task<IEnumerable<T>> GetManyAsync(ISpecification<T> spec)
    {
        var query = Set.AsQueryable();
        return await ApplySpecification(query, spec)
            .ToListAsync();
    }
    public virtual async Task<IEnumerable<TOut>> GetManyAsync<TOut>(ISpecification<T, TOut> spec)
        where TOut : class
    {
        var query = Set.AsQueryable();
        return await ApplySpecification(query, spec)
            .ToListAsync();
    }

    public virtual async Task<T?> GetOneAsync(ISpecification<T> spec)
    {
        var query = Set.AsQueryable();
        return await ApplySpecification(query, spec)
            .FirstOrDefaultAsync();
    }
    public virtual async Task<TOut?> GetOneAsync<TOut>(ISpecification<T, TOut> spec)
        where TOut : class
    {
        var query = Set.AsQueryable();
        return await ApplySpecification(query, spec)
            .FirstOrDefaultAsync();
    }

    public virtual async Task AddAsync(T entity)
    {
        await Set.AddAsync(entity);
    }

    public virtual async Task DeleteAsync(ISpecification<T> spec)
    {
        var entity = await GetOneAsync(spec);
        Set.Remove(entity);
    }
    public virtual async Task DeleteAsync(T entity)
    {
        Set.Remove(entity);
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
