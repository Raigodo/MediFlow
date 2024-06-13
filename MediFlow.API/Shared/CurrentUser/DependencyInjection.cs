namespace MediFlow.API.Shared.CurrentUser;

public static class DependencyInjection
{
    public static IServiceCollection AddUserContext(this IServiceCollection services)
    {
        services.AddTransient<IUserContext, UserContext>();
        return services;
    }
}
