using Mediator;
using MediFlow.API.Modules.Auth.Domain.User;
using MediFlow.API.Modules.Journal.Data;
using MediFlow.API.Modules.Journal.Domain.Notes;
using MediFlow.API.Modules.Journal.Domain.Persons.Values;
using MediFlow.API.Shared.CurrentUser;
using Microsoft.AspNetCore.Identity;

namespace MediFlow.API.Modules.Journal.UseCases.Notes.CreateNote;

public class CreateNoteRequestHandler(
    JournalDbContext dbCtx,
    UserManager<User> userManager,
    IUserContext userCtx) : IRequestHandler<CreateNoteRequest, IResult>
{
    public async ValueTask<IResult> Handle(CreateNoteRequest request, CancellationToken cancellationToken)
    {
        var userId = (await userManager.FindByEmailAsync(userCtx.UserEmail))!.Id;

        var newNote = new Note()
        {
            CreatorId = userId,
            TargetPersonId = new PersonId(request.TargetPersonId),
            NoteBody = request.noteContent,
            NoteTag = "test-note-tag"
        };
        await dbCtx.Notes.AddAsync(newNote);
        dbCtx.SaveChanges();
        return Results.Ok(newNote);
    }
}
