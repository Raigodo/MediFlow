using FastEndpoints;

namespace Journal.Features.Notes.Endpoints.Delete;

public sealed class DeleteNoteEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Delete("notes");
        AllowAnonymous();
    }


    public override async Task HandleAsync(CancellationToken c)
    {
        await SendAsync(new { Message = "Done" }, cancellation: c);
    }
}