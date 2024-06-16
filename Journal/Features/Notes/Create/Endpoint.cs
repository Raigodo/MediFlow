using FastEndpoints;

namespace Journal.Features.Notes.Create;

public sealed class Endpoint : Endpoint<JournalRequest, JournalResponse>
{
    public override void Configure()
    {
        Post("notes");
        AllowAnonymous();
    }

    public override async Task HandleAsync(JournalRequest r, CancellationToken c)
    {
        await SendAsync(new JournalResponse("Hello World!"), cancellation: c);
    }
}