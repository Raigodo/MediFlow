using MediFlow.API.Shared.MediateRoutes;

namespace MediFlow.API.Modules.Journal.UseCases.Notes.GetNotes;

public record GetNotesQuery(Guid personId) : IHttpRequest;
