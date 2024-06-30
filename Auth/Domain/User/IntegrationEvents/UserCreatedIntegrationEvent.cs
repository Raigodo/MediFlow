namespace Account.Domain.User.IntegrationEvents;

public sealed record UserCreatedIntegrationEvent(Guid userId, string userName);
