using Journal.Domain.Notes;
using Journal.Domain.Services;

namespace Journal.Data.Services;

public class AcessGuardService : IAcessGuardService
{
    private readonly IJournalDbContext _journalDbContext;

    public AcessGuardService(IJournalDbContext journalDbContext)
    {
        _journalDbContext = journalDbContext;
    }

    public Task<bool> HasRightsToAcessPersonAsync(Guid userId, Guid personId)
    {
        throw new NotImplementedException();
    }

    public bool HasRightsToModiffyNote(Guid userId, Note note)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasRightsToModiffyNoteAsync(Guid userId, Guid noteId)
    {
        throw new NotImplementedException();
    }
}
