using MediFlow.API.Modules.Account.Domain.User;
using Microsoft.AspNetCore.Identity;

namespace MediFlow.API.Shared.CurrentUser;

internal sealed class UserContext(
    IHttpContextAccessor httpContextAccessor,
    UserManager<User> userManager)
    : IUserContext
{
    public bool IsAuthenticated =>
        httpContextAccessor
            .HttpContext?
            .User
            .Identity?
            .IsAuthenticated ??
        throw new ApplicationException("User context is unavailable");


    public async Task<UserId> GetUserIdAsync()
    {
        var usersEmail = httpContextAccessor
           .HttpContext?
           .User
           .Identity?
           .Name ??
           throw new ApplicationException("User context is unavailable");

        var currentUser = await userManager.FindByEmailAsync(usersEmail);

        return currentUser?.Id ??
           throw new ApplicationException($"User with email {usersEmail} was not found");

    }
}