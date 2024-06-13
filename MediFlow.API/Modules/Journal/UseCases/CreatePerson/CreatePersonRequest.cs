using MediFlow.API.Shared.MediateRoutes;

namespace MediFlow.API.Modules.Journal.UseCases.CreatePerson;

public record CreatePersonRequest(Guid Id, string Name) : IHttpRequest;