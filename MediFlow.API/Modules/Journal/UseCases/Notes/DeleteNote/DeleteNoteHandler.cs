using Mediator;
using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.Domain.Notes.Values;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.API.Modules.Journal.UseCases.Notes.DeleteNote;

public class DeleteNoteHandler(JournalDbContext dbCtx) : IRequestHandler<DeleteNote, IResult>
{
    public async ValueTask<IResult> Handle(DeleteNote request, CancellationToken cancellationToken)
    {
        var note = await dbCtx.Notes
            .Where(n => n.NoteId == new NoteId(request.NoteId))
            .FirstOrDefaultAsync();
        if (note == null)
        {
            return Results.NotFound();
        }
        dbCtx.Remove(note);
        dbCtx.SaveChanges();
        return Results.Ok();
    }
}
