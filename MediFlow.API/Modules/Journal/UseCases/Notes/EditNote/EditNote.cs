using MediFlow.API.Shared.MediateRoutes;

namespace MediFlow.API.Modules.Journal.UseCases.Notes.EditNote;

public record EditNote(Guid NoteId, Guid PersonId, string NoteBody, string NoteTag) : IHttpRequest;
