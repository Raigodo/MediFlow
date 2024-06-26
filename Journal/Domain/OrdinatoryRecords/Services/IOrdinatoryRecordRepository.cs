namespace Journal.Domain.OrdinatoryRecords.Services;

public interface IOrdinatoryRecordRepository
{
    Task AddAsync(OrdinatoryRecord note, CancellationToken ct = default);
    Task DeleteAsync(OrdinatoryRecord note, CancellationToken ct = default);
    Task<OrdinatoryRecord?> GetById(Guid id, CancellationToken ct = default);
    Task<IEnumerable<OrdinatoryRecord>> GetByPersonId(Guid id, CancellationToken ct = default);
}
