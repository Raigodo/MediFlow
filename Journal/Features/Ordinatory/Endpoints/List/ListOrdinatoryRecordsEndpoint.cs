using FastEndpoints;

namespace Journal.Features.Ordinatory.Endpoints.List;

public sealed class ListOrdinatoryRecordsEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("ordinatory");
        AllowAnonymous();
    }


    public override async Task HandleAsync(CancellationToken c)
    {
        await SendAsync(new { Message = "Done" }, cancellation: c);
    }
}