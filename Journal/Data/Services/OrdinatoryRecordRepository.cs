using Journal.Domain.OrdinatoryRecords;
using Journal.Domain.OrdinatoryRecords.Services;
using Microsoft.EntityFrameworkCore;

namespace Journal.Data.Services;

public sealed class OrdinatoryRecordRepository : IOrdinatoryRecordRepository
{
    public OrdinatoryRecordRepository(IJournalDbContext dbContext)
    {
        journalDbContext = dbContext;
    }

    private readonly IJournalDbContext journalDbContext;


    public async Task AddAsync(OrdinatoryRecord ordinatoryRecord, CancellationToken ct = default)
    {
        journalDbContext.OrdinatoryRecords
            .Add(ordinatoryRecord);
        await journalDbContext.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(OrdinatoryRecord ordinatoryRecord, CancellationToken ct = default)
    {
        journalDbContext.OrdinatoryRecords
            .Remove(ordinatoryRecord);
        await journalDbContext.SaveChangesAsync(ct);
    }

    public async Task<OrdinatoryRecord?> GetById(Guid id, CancellationToken ct = default)
    {
        return await journalDbContext.OrdinatoryRecords
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(ct);
    }

    public async Task<IEnumerable<OrdinatoryRecord>> GetByPersonId(Guid id, CancellationToken ct = default)
    {
        return await journalDbContext.OrdinatoryRecords
            .Where(x => x.TargetPersonId == id)
            .ToListAsync(ct);
    }
}
