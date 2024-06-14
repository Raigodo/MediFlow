using Mediator;
using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.Domain.Notes;
using MediFlow.API.Modules.Journal.Domain.Persons.Values;
using MediFlow.API.Shared.CurrentUser;

namespace MediFlow.API.Modules.Journal.UseCases.Notes.CreateNote;

public class CreateNoteHandler(
    JournalDbContext dbCtx,
    IUserContext userCtx) : IRequestHandler<CreateNote, IResult>
{
    public async ValueTask<IResult> Handle(CreateNote request, CancellationToken cancellationToken)
    {
        var newNote = new Note()
        {
            CreatorId = await userCtx.GetUserIdAsync(),
            TargetPersonId = new PersonId(request.PersonId),
            NoteBody = request.NoteContent,
            NoteTag = "test-note-tag"
        };
        await dbCtx.Notes.AddAsync(newNote);
        dbCtx.SaveChanges();
        return Results.Ok(newNote);
    }
}
