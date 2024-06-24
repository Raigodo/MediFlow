using Journal.Domain.Notes;
using Journal.Domain.Notes.Services;

namespace Journal.Features.Notes.Services;

public sealed class NoteService : INoteService
{
    public Note Create(Guid creatorId, Guid targetPersonId, string noteBody, string noteTag)
    {
        throw new NotImplementedException();
    }
}
