using FastEndpoints;

namespace Journal.Features.Notes.Endpoints.Edit;

public sealed class EditNoteEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Patch("notes/{id}");
        AllowAnonymous();
    }


    public override async Task HandleAsync(CancellationToken c)
    {
        await SendAsync(new { Message = "Done" }, cancellation: c);
    }
}