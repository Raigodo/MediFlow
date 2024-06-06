using Mediator;
using MediFlow.API.Modules.Journal.Domain.Models;
using MediFlow.API.Shared.Util.Result;

namespace MediFlow.API.Modules.Journal.UseCases.CreateNote;

public class CreateNoteRequestHandler : IRequestHandler<CreateNoteRequest, Result<Note>>
{
    public async ValueTask<Result<Note>> Handle(CreateNoteRequest request, CancellationToken cancellationToken)
    {
        return Result<Note>.Success(null);
    }
}
