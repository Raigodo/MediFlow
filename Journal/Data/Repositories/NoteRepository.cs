using Journal.Domain.Notes;
using Journal.Domain.Notes.Services;
using Microsoft.EntityFrameworkCore;

namespace Journal.Data.Repositories;

public sealed class NoteRepository : INoteRepository
{
    public NoteRepository(IJournalDbContext dbContext)
    {
        journalDbContext = dbContext;
    }

    private readonly IJournalDbContext journalDbContext;


    public async Task AddAsync(Note note, CancellationToken ct = default)
    {
        journalDbContext.Notes
            .Add(note);
        await journalDbContext.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Note note, CancellationToken ct = default)
    {
        journalDbContext.Notes
            .Remove(note);
        await journalDbContext.SaveChangesAsync(ct);
    }

    public async Task<Note?> GetById(Guid id, CancellationToken ct = default)
    {
        return await journalDbContext.Notes
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(ct);
    }

    public async Task<IEnumerable<Note>> GetByPersonId(Guid id, CancellationToken ct = default)
    {
        return await journalDbContext.Notes
            .Where(x => x.TargetPersonId == id)
            .ToListAsync(ct);
    }
}
