using Journal.Shared.StronglyTypedId;

namespace Journal.Domain.Persons.Values;

public readonly record struct PersonId(Guid Value) : ITypedId;

