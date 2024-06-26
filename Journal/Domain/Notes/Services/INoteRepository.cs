namespace Journal.Domain.Notes.Services;

public interface INoteRepository
{
    Task AddAsync(Note note, CancellationToken ct = default);
    Task DeleteAsync(Note note, CancellationToken ct = default);
    Task<Note?> GetById(Guid id, CancellationToken ct = default);
    Task<IEnumerable<Note>> GetByPersonId(Guid id, CancellationToken ct = default);
}
