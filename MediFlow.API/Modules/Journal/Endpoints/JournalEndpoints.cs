using Mediator;
using MediFlow.API.Modules.Journal.UseCases.CreateNote;
using MediFlow.API.Modules.Journal.UseCases.CreatePerson;
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
        return result.Match(
            note => Results.Ok(note),
            error =>
            {
                return Results.Problem();
            });
    }

    public static async Task<IResult> CreatePerson(string personId, string Name, IMediator mediator)
    {
        return Results.Ok(await mediator.Send(new CreatePersonRequest(personId, Name)));
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
        var result = await mediator.Send(new GetNotesQuery(personId), cancellationToken);
        return result.Match(notes => Results.Ok(notes), err => Results.BadRequest(err));
    }
}
