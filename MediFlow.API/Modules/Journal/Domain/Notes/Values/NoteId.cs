using MediFlow.API.Shared.StronglyTypedId;

namespace MediFlow.API.Modules.Journal.Domain.Notes.Values;

public readonly record struct NoteId(Guid Value) : ITypedId;
