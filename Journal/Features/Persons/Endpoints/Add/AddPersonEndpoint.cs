using FastEndpoints;
using Journal.Data;

namespace Journal.Features.Persons.Endpoints.Add;

public sealed class AddPersonEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("persons");
        AllowAnonymous();
    }

    public required JournalDbContext DbCtx { get; set; }

    public override async Task HandleAsync(CancellationToken c)
    {
        //DbCtx.Database.EnsureDeleted();
        //DbCtx.Database.EnsureCreated();
        //var person = Person.Create("some name");
        //DbCtx.Persons.Add(person);
        //DbCtx.SaveChanges();
        var persons = DbCtx.Persons.ToArray();
        await SendAsync(persons, cancellation: c);
    }
}
