using MediFlow.API.Shared.MediateRoutes;

namespace MediFlow.API.Modules.Journal.UseCases.Notes.CreateNote;

public record CreateNoteRequest(Guid TargetPersonId, string noteContent) : IHttpRequest;