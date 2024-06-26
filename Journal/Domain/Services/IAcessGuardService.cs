using Journal.Domain.Notes;

namespace Journal.Domain.Services;

public interface IAcessGuardService
{
    Task<bool> HasRightsToAcessPersonAsync(Guid userId, Guid personId);
    Task<bool> HasRightsToModiffyNoteAsync(Guid userId, Guid noteId);
    bool HasRightsToModiffyNote(Guid userId, Note note);
}
