using MediFlow.API.DependencyInjection;
using MediFlow.API.Modules.Auth;
using MediFlow.API.Modules.Journal;
using MediFlow.API.Shared.CurrentUser;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddUserContext();
builder.Services.AddAuthModule();
builder.Services.AddJournalModule();

builder.Services.AddMediator(options =>
{
    options.ServiceLifetime = ServiceLifetime.Scoped;
});

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

app.UseAuthModule();
app.UseJournalModule();


app.Run();
