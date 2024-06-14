using Mediator;
using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.Domain.Persons;
using MediFlow.API.Modules.Journal.Domain.Persons.Values;

namespace MediFlow.API.Modules.Journal.UseCases.Persons;

public class CreatePersonHandler(JournalDbContext dbCtx) : IRequestHandler<CreatePerson, IResult>
{
    public async ValueTask<IResult> Handle(
        CreatePerson request,
        CancellationToken cancellationToken)
    {
        var newPerson = new Person()
        {
            Id = new PersonId(request.PersonId),
            Name = request.Name,
        };
        await dbCtx.Persons.AddAsync(newPerson);
        dbCtx.SaveChanges();
        return Results.Ok(newPerson);
    }
}