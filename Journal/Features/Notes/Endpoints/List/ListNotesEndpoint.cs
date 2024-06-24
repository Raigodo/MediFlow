using FastEndpoints;

namespace Journal.Features.Notes.Endpoints.List;

public sealed class ListNotesEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("notes");
        AllowAnonymous();
    }


    public override async Task HandleAsync(CancellationToken c)
    {
        await SendAsync(new { Message = "Done" }, cancellation: c);
    }
}