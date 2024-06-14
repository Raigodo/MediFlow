using Mediator;
using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.Domain.Notes.Values;
using MediFlow.API.Modules.Journal.Domain.Persons.Values;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.API.Modules.Journal.UseCases.Notes.EditNote;

public class EditNoteHandler(JournalDbContext dbCtx) : IRequestHandler<EditNote, IResult>
{
    public async ValueTask<IResult> Handle(EditNote request, CancellationToken cancellationToken)
    {
        var note = await dbCtx.Notes
            .Where(n => n.NoteId == new NoteId(request.NoteId))
            .FirstOrDefaultAsync();

        if (note == null)
            return Results.NotFound();

        note.TargetPersonId = new PersonId(request.PersonId);
        note.NoteTag = request.NoteTag;
        note.NoteBody = request.NoteBody;
        note.ModifiedAt = DateTime.UtcNow;

        dbCtx.SaveChanges();
        return Results.Ok();
    }
}
