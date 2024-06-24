using FastEndpoints;
using Journal.Data;
using Journal.Domain.Persons;

namespace Journal.Features.Persons.Endpoints.Add;

public sealed class AddPersonEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("persons");
        AllowAnonymous();
    }

    public required IJournalDbContext DbCtx { get; set; }

    public override async Task HandleAsync(CancellationToken c)
    {
        await DbCtx.Persons.AddAsync(Person.Create("some name"));
        await DbCtx.SaveChangesAsync(c);
        var persons = DbCtx.Persons.ToArray();
        await SendAsync(persons, cancellation: c);
    }
}
