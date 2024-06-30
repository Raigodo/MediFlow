using Journal;
using MediFlow.API.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediator(options =>
    options.ServiceLifetime = ServiceLifetime.Scoped);

builder.Services.AddAuthModule(builder.Configuration);
builder.Services.AddJournalModule();

builder.Services.AddJwtAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenWithJwtAuthSupport();

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


