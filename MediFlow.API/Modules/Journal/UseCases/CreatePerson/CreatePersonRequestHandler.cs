using Mediator;
using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.Domain.Persons;
using MediFlow.API.Modules.Journal.Domain.Persons.Values;
using MediFlow.API.Shared.CurrentUser;

namespace MediFlow.API.Modules.Journal.UseCases.CreatePerson;

public class CreatePersonRequestHandler(
    JournalDbContext dbCtx,
    IUserContext userCtx) : IRequestHandler<CreatePersonRequest, IResult>
{
    public async ValueTask<IResult> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
    {
        var newPerson = new Person()
        {
            Id = new PersonId(request.Id),
            Name = request.Name,
        };
        await dbCtx.Persons.AddAsync(newPerson);
        dbCtx.SaveChanges();
        return Results.Ok(newPerson);
    }
}
