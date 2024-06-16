namespace Journal.Domain.OrdinatoryRecords.Contracts;

public interface IOrdinatoryRecordRepository
{
    Task AddAsync(OrdinatoryRecord note);
    Task DeleteAsync(OrdinatoryRecord note);
    Task<OrdinatoryRecord> GetAsync(string noteId);
    Task<IEnumerable<OrdinatoryRecord>> GetForPersonAsync(string personId);
}
