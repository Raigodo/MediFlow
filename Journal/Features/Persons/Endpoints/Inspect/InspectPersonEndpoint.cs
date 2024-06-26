using FastEndpoints;
using Journal.Domain.Persons.Services;

namespace Journal.Features.Persons.Endpoints.Inspect;

public sealed class InspectPersonEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("persons/{id}");
        AllowAnonymous();
    }

    public required IPersonRepository PersonRepository { get; set; }

    public override async Task HandleAsync(CancellationToken c)
    {
        await SendAsync("not implemented yet", cancellation: c);
    }
}