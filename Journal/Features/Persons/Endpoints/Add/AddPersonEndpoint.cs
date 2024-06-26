using FastEndpoints;
using Journal.Domain.Persons;
using Journal.Domain.Persons.Services;

namespace Journal.Features.Persons.Endpoints.Add;

public sealed class AddPersonEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("persons");
        AllowAnonymous();
    }

    public required IPersonRepository Persons { get; set; }

    public override async Task HandleAsync(CancellationToken c)
    {
        var person = Person.Create("some name");
        await Persons.AddAsync(person);
        await SendAsync("lets say ok", cancellation: c);
    }
}