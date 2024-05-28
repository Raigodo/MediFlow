using MediFlow.API.Features.Dummy.UseCases.Test1;
using MediFlow.API.Modules.Dummy.UseCases.Test1;
using MediFlow.API.Shared;

namespace MediFlow.API.Modules.Dummy;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddDummyModule(this WebApplicationBuilder builder)
    {
        //add services and dependencies

        return builder;
    }

    public static WebApplication UseDummyModule(this WebApplication app)
    {
        //map routes
        app.MapGroup("/api/v1/dummy")
            .Also(g =>
            {
                g.MediateGet<Test1Request>("/test1");
                g.MediateGet<Test2Request>("/test2");
            })
            .WithTags("Dummy Routes")
            .RequireAuthorization();

        return app;
    }
}
