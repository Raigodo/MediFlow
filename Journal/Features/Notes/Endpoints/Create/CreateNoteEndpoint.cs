using FastEndpoints;

namespace Journal.Features.Notes.Endpoints.Create;

public sealed class CreateNoteEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("notes");
        AllowAnonymous();
    }


    public override async Task HandleAsync(CancellationToken c)
    {
        await SendAsync("ok", cancellation: c);
    }
}