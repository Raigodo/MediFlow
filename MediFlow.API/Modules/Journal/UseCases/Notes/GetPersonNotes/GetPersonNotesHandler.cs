using Mediator;
using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.Domain.Persons.Values;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.API.Modules.Journal.UseCases.Notes.GetPersonNotes;

public class GetPersonNotesHandler(JournalDbContext dbCtx) : IRequestHandler<GetPersonNotes, IResult>
{
    public async ValueTask<IResult> Handle(
        GetPersonNotes request,
        CancellationToken cancellationToken)
    {
        var notes = await dbCtx.Notes
            .Where(p => p.TargetPersonId == new PersonId(request.PersonId))
            .ToListAsync();

        return Results.Ok(notes);
    }
}
