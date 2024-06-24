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

builder.Services.AddJournalModule();

builder.Services.AddSwagger();


var app = builder.Build();



//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseFastEndpoints()
    .UseSwaggerGen();


//app.UseAuthentication();
//app.UseAuthorization();



app.Run();


