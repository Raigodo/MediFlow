using MediFlow.API.Shared.StronglyTypedId;

namespace MediFlow.API.Modules.Account.Domain.User;

public readonly record struct UserId(Guid Value) : ITypedId;
