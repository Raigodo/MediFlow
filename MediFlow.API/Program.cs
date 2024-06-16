using FastEndpoints;
using Journal;
using MediFlow.API.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

//builder.Services.AddUserContext();

builder.Services.AddFastEndpoints(options =>
{
    options.DisableAutoDiscovery = true;
    options.Assemblies = new[]
    {
        typeof(Program).Assembly,
        typeof(IJournalModulePointer).Assembly
    };
});

//builder.Services.AddAuthModule();
builder.Services.AddJournalModule();


builder.Services.AddSwagger();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints();

app.Run();
