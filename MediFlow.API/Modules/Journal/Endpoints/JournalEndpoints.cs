using Mediator;
using MediFlow.API.Modules.Journal.UseCases.CreateNote;
using MediFlow.API.Modules.Journal.UseCases.GetNotes;
using System.Security.Claims;

namespace MediFlow.API.Modules.Journal.Endpoints;

public static class JournalEndpoints
{
    public static async Task<IResult> CreateJournalNote(
        string personId, string noteContent, ClaimsPrincipal currentUser,
        IMediator mediator, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateNoteRequest(personId, noteContent, currentUser.Identity!.Name!), cancellationToken);
        return Results.Ok(result);
    }

    public static async Task<IResult> DeleteJournalNote()
    {
        return Results.Ok("delete journal note");
    }

    public static async Task<IResult> EditJournalNote()
    {
        return Results.Ok("edit journal note");
    }

    public static async Task<IResult> QueryJournalNotes(
        string personId, ClaimsPrincipal currentUser,
        IMediator mediator, CancellationToken cancellationToken)
    {
        var notes = await mediator.Send(new GetNotesQuery(personId), cancellationToken);
        return Results.Ok(notes);
    }
}
