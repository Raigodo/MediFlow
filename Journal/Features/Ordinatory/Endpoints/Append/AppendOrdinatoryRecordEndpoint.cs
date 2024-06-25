using FastEndpoints;

namespace Journal.Features.Ordinatory.Endpoints.Append;

public sealed class AppendOrdinatoryRecordEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("ordinatory");
        AllowAnonymous();
    }


    public override async Task HandleAsync(CancellationToken c)
    {
        await SendAsync("not implemented", cancellation: c);
    }
}