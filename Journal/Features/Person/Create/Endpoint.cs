using FastEndpoints;
using Journal.Data;

namespace Journal.Features.Notes.Create;

public sealed class Endpoint : Endpoint<CreateNoteRequest>
{
    public override void Configure()
    {
        Post("notes");
        AllowAnonymous();
    }

    public JournalDbContext Db { get; set; }

    public override async Task HandleAsync(CreateNoteRequest r, CancellationToken c)
    {
        await SendAsync(new { Message = "Hi" }, cancellation: c);
    }
}