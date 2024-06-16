using Journal.Shared.StronglyTypedId;

namespace Journal.Domain.OrdinatoryRecords.Values;

public readonly record struct OrdinatoryRecordId(Guid Value) : ITypedId;
