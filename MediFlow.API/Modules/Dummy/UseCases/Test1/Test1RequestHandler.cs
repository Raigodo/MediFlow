using Mediator;
using MediFlow.API.Shared;

namespace MediFlow.API.Modules.Dummy.UseCases.Test1;

public class Test1RequestHandler : IRequestHandler<Test1Request, IResult>
{
    public ValueTask<IResult> Handle(Test1Request request, CancellationToken cancellationToken)
    {
        return Results.Ok($"hello {request.user.Identity!.Name}, data got: {request.someData}").ToValueTask();
    }
}
