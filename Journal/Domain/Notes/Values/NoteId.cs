using Journal.Shared.StronglyTypedId;

namespace Journal.Domain.Notes.Values;

public readonly record struct NoteId(Guid Value) : ITypedId;
