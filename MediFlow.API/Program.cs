using FastEndpoints;
using FastEndpoints.Swagger;
using Journal;
using MediFlow.API.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddFastEndpoints(options =>
{
    options.DisableAutoDiscovery = true;
    options.Assemblies = [
        typeof(IJournalModulePointer).Assembly,
    ];
});
builder.Services.SwaggerDocument();
builder.Services.AddSwaggerWithAuthSupport();

builder.Services.AddJournalModule();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseFastEndpoints()
    .UseSwaggerGen();


//app.UseAuthentication();
//app.UseAuthorization();



app.Run();


