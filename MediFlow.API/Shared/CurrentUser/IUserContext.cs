namespace MediFlow.API.Shared.CurrentUser;

public interface IUserContext
{
    bool IsAuthenticated { get; }

    string UserEmail { get; }
}
