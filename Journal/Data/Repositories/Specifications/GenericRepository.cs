using Microsoft.EntityFrameworkCore;

namespace Journal.Data.Repositories.Specifications;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected abstract DbSet<T> Set { get; }

    public virtual async Task<IEnumerable<T>> GetManyAsync() => await Set.ToListAsync();
    public virtual async Task<IEnumerable<T>> GetManyAsync(ISpecification<T> spec)
    {
        var query = Set.AsQueryable();
        return await ApplySpecification(query, spec)
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();
    }
    public virtual async Task<IEnumerable<TOut>> GetManyAsync<TOut>(ISpecification<T, TOut> spec)
        where TOut : class
    {
        var query = Set.AsQueryable();
        return await ApplySpecification(query, spec)
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();
    }

    public virtual async Task<T?> GetFirstAsync(ISpecification<T> spec)
    {
        var query = Set.AsQueryable();
        return await ApplySpecification(query, spec)
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync();
    }
    public virtual async Task<TOut?> GetFirstAsync<TOut>(ISpecification<T, TOut> spec)
        where TOut : class
    {
        var query = Set.AsQueryable();
        return await ApplySpecification(query, spec)
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync();
    }

    public virtual void Add(T entity)
    {
        Set.Add(entity);
    }

    public virtual void Update(T entity)
    {
        Set.Update(entity);
    }

    public virtual async Task DeleteAsync(ISpecification<T> spec)
    {
        var entity = await GetFirstAsync(spec);
        Set.Remove(entity);
    }
    public virtual void Delete(T entity)
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
