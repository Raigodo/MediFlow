using FastEndpoints;

namespace Journal.Features.Ordinatory.Endpoints.Modiffy;

public sealed class ModiffyOrdinatoryRecordEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Patch("ordinatory/{id}");
        AllowAnonymous();
    }


    public override async Task HandleAsync(CancellationToken c)
    {
        await SendAsync("not implemented", cancellation: c);
    }
}