using MediFlow.API.Modules.Account.Domain.User;

namespace MediFlow.API.Shared.CurrentUser;

public interface IUserContext
{
    bool IsAuthenticated { get; }

    Task<UserId> GetUserIdAsync();
}
