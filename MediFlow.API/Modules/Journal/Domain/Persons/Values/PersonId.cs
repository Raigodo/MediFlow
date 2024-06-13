using MediFlow.API.Shared.StronglyTypedId;

namespace MediFlow.API.Modules.Journal.Domain.Persons.Values;

public readonly record struct PersonId(Guid Value) : ITypedId;

