using Mediator;
using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.Domain.Notes;
using MediFlow.API.Shared.Util.Result;

namespace MediFlow.API.Modules.Journal.UseCases.CreateNote;

public class CreateNoteRequestHandler(
    JournalDbContext dbCtx) : IRequestHandler<CreateNoteRequest, Result<Note>>
{
    public async ValueTask<Result<Note>> Handle(CreateNoteRequest request, CancellationToken cancellationToken)
    {
        var newNote = new Note()
        {
            CreatorId = request.creatorId,
            TargetPersonId = request.TargetPersonId,
            NoteBody = request.noteContent,
            NoteTag = "test-note-tag"
        };
        await dbCtx.Notes.AddAsync(newNote);
        dbCtx.SaveChanges();
        return newNote;
    }
}
