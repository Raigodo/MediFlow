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
        var groupBuilder = app.MapGroup("/api/v1/dummy")
            .WithTags("Dummy Routes")
            .RequireAuthorization();

        groupBuilder.MediateGet<Test1Request>("/test1");
        groupBuilder.MediateGet<Test2Request>("/test2");
            

        return app;
    }
}
