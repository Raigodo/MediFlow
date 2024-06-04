using Mediator;

namespace MediFlow.API.Shared;

public static class MapEnpointsExtensions
{
    public static RouteHandlerBuilder MediateGet<TRequest>(this IEndpointRouteBuilder app,
        string template) where TRequest : IHttpRequest
    {
        return app.MapGet(template, async ([AsParameters] TRequest request,
            IMediator mediator) => await mediator.Send(request));
    }


    public static RouteHandlerBuilder MediatePost<TRequest>(this IEndpointRouteBuilder app,
        string template) where TRequest : IHttpRequest
    {
        return app.MapPost(template, async ([AsParameters] TRequest request,
            IMediator mediator) => await mediator.Send(request));
    }


    public static RouteHandlerBuilder MediatePut<TRequest>(this IEndpointRouteBuilder app,
        string template) where TRequest : IHttpRequest
    {
        return app.MapPut(template, async ([AsParameters] TRequest request,
            IMediator mediator) => await mediator.Send(request));
    }


    public static RouteHandlerBuilder MediatePatch<TRequest>(this IEndpointRouteBuilder app,
        string template) where TRequest : IHttpRequest
    {
        return app.MapPatch(template, async ([AsParameters] TRequest request,
            IMediator mediator) => await mediator.Send(request));
    }


    public static RouteHandlerBuilder MediateDelete<TRequest>(this IEndpointRouteBuilder app,
        string template) where TRequest : IHttpRequest
    {
        return app.MapDelete(template, async ([AsParameters] TRequest request,
            IMediator mediator) => await mediator.Send(request));
    }
}
