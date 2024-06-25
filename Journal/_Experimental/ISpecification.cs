namespace Journal.Experimental;

public interface ISpecification<T> where T : class
{
    IQueryable<T> ApplyFiltering(IQueryable<T> query);
    IQueryable<T> ApplyJoining(IQueryable<T> query);
    IQueryable<T> ApplyOrdering(IQueryable<T> query);
}

public interface ISpecification<TEntity, TOut> : ISpecification<TEntity>
    where TEntity : class
    where TOut : class
{
    IQueryable<TOut> ApplyMapping(IQueryable<TEntity> query);
}