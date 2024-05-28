namespace MediFlow.API.Shared;

public static class EnpointGroupExtensions
{
    public static RouteGroupBuilder Also(this RouteGroupBuilder group, Action<RouteGroupBuilder> mapRoutes)
    {
        mapRoutes(group);
        return group;
    }
}
