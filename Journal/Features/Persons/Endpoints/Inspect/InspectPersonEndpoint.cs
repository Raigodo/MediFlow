using FastEndpoints;

namespace Journal.Features.Persons.Endpoints.Inspect;

public sealed class InspectPersonEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("persons/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken c)
    {
        await SendAsync("ok", cancellation: c);
    }
}