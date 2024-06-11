using Mediator;
using MediFlow.API.Modules.Journal.Domain.Persons;
using MediFlow.API.Shared.Util.Result;

namespace MediFlow.API.Modules.Journal.UseCases.CreatePerson;

public record CreatePersonRequest(string Id, string Name) : IRequest<ErrorOr<Person>>;