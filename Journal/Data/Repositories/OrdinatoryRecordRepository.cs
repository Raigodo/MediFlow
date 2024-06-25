using Journal.Data.Repositories.Specifications;
using Journal.Domain.OrdinatoryRecords;
using Journal.Domain.OrdinatoryRecords.Services;
using Microsoft.EntityFrameworkCore;

namespace Journal.Data.Repositories;

public sealed class OrdinatoryRecordRepository : GenericRepository<OrdinatoryRecord>, IOrdinatoryRecordRepository
{
    public OrdinatoryRecordRepository(IJournalDbContext dbContext)
    {
        Set = dbContext.OrdinatoryRecords;
    }

    protected override DbSet<OrdinatoryRecord> Set { get; }
}
