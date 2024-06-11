using Mediator;
using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.Domain.Notes;
using MediFlow.API.Shared.Util.Result;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.API.Modules.Journal.UseCases.GetNotes;

public class GetNotesQueryHandler(
    JournalDbContext dbCtx) : IQueryHandler<GetNotesQuery, Result<IEnumerable<Note>>>
{
    public async ValueTask<Result<IEnumerable<Note>>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = await dbCtx.Notes.Where(n => n.TargetPersonId == request.personId).ToListAsync();
        return notes;
    }
}
