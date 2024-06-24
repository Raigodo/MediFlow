using FastEndpoints;
using Journal.Data;

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
        await SendAsync(new { persons = "Ok" }, cancellation: c);
    }
}
