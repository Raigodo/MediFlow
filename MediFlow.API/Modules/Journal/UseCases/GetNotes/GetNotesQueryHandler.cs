using Mediator;
using MediFlow.API.Modules.Journal.Domain.Models;
using MediFlow.API.Shared.Util.Result;

namespace MediFlow.API.Modules.Journal.UseCases.GetNotes;

public class GetNotesQueryHandler : IQueryHandler<GetNotesQuery, Result<IEnumerable<Note>>>
{
    public async ValueTask<Result<IEnumerable<Note>>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        return Result<IEnumerable<Note>>.Success([]);
    }
}
