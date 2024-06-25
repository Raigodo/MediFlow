using FastEndpoints;

namespace Journal.Features.Persons.Endpoints.List;

public sealed class ListPersonsEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("persons");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken c)
    {
        await SendAsync("not implemented", cancellation: c);
    }
}
