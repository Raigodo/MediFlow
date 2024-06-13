using MediFlow.API.Shared.StronglyTypedId;

namespace MediFlow.API.Modules.Journal.Domain.OrdinatoryRecords.Values;

public readonly record struct OrdinatoryRecordId(Guid Value) : ITypedId;
