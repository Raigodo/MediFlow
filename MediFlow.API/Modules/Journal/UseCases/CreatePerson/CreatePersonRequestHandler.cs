using Mediator;
using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.Domain.Persons;

namespace MediFlow.API.Modules.Journal.UseCases.CreatePerson;

public class CreatePersonRequestHandler(
    JournalDbContext dbCtx) : IRequestHandler<CreatePersonRequest, Person>
{
    public async ValueTask<Person> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
    {
        var newPerson = new Person()
        {
            Id = request.Id,
            Name = request.Name,
        };
        await dbCtx.Persons.AddAsync(newPerson);
        dbCtx.SaveChanges();
        return newPerson;
    }
}
