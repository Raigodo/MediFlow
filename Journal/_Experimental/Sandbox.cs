using Journal.Experimental;

namespace Journal._Experimental;

public class Sandbox
{
    async Task Foo()
    {
        var repository = new MyRepository();

        //it is AType?
        var mustBeA = await repository.GetOneAsync(new ASpec());

        //is is BType?
        var mustBeB = await repository.GetOneAsync(new AToBSpec());


        //doesnt compile
        //BType shouldntWork = await repository.GetOneAsync(new BSpec());

        //also doesnt compile
        //AType shouldntCompile = await repository.GetOneAsync(new BToASpec());

    }
}

class ASpec : ISpecification<AType>
{
    public IQueryable<AType> ApplyFiltering(IQueryable<AType> query) => query;
    public IQueryable<AType> ApplyJoining(IQueryable<AType> query) => query;
    public IQueryable<AType> ApplyOrdering(IQueryable<AType> query) => query;
}

class BSpec : ISpecification<BType>
{
    public IQueryable<BType> ApplyFiltering(IQueryable<BType> query) => query;
    public IQueryable<BType> ApplyJoining(IQueryable<BType> query) => query;
    public IQueryable<BType> ApplyOrdering(IQueryable<BType> query) => query;
}


class AToBSpec : ISpecification<AType, BType>
{
    public IQueryable<AType> ApplyFiltering(IQueryable<AType> query) => query;
    public IQueryable<AType> ApplyJoining(IQueryable<AType> query) => query;

    public IQueryable<BType> ApplyMapping(IQueryable<AType> query)
        => query.Select(a => new BType(a.x));

    public IQueryable<AType> ApplyOrdering(IQueryable<AType> query) => query;
}

class BToASpec : ISpecification<BType, AType>
{
    public IQueryable<BType> ApplyFiltering(IQueryable<BType> query) => query;
    public IQueryable<BType> ApplyJoining(IQueryable<BType> query) => query;
    public IQueryable<BType> ApplyOrdering(IQueryable<BType> query) => query;
    public IQueryable<AType> ApplyMapping(IQueryable<BType> query)
        => query.Select(b => new AType(b.x));
}

record AType(int x);
record BType(int x);

class MyRepository : GenericRepository<AType>;