namespace MediFlow.API.Shared.CurrentUser;

internal sealed class UserContext(IHttpContextAccessor httpContextAccessor)
    : IUserContext
{
    public string UserEmail =>
        httpContextAccessor
            .HttpContext?
            .User
            .Identity?
            .Name ??
        throw new ApplicationException("User context is unavailable");

    public bool IsAuthenticated =>
        httpContextAccessor
            .HttpContext?
            .User
            .Identity?
            .IsAuthenticated ??
        throw new ApplicationException("User context is unavailable");
}