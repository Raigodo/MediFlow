using MediFlow.API.Shared.StronglyTypedId;

namespace MediFlow.API.Modules.Auth.Domain.User;

public readonly record struct UserId(Guid Value) : ITypedId;
