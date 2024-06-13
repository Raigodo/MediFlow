using Mediator;
using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.Domain.Persons.Values;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.API.Modules.Journal.UseCases.Notes.GetNotes;

public class GetNotesQueryHandler(
    JournalDbContext dbCtx) : IRequestHandler<GetNotesQuery, IResult>
{
    public async ValueTask<IResult> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = await dbCtx.Notes.Where(n => n.TargetPersonId == new PersonId(request.personId)).ToListAsync();
        return Results.Ok(notes);
    }
}
