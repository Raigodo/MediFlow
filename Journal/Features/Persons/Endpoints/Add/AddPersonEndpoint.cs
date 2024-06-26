using FastEndpoints;
using Journal.Domain.Persons.Services;
using Journal.Domain.Services;
using Microsoft.AspNetCore.Authorization;

namespace Journal.Features.Persons.Endpoints.Add;

public sealed class AddPersonEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("persons");
        AllowAnonymous();
    }

    public required IPersonRepository Persons { get; init; }
    public required IAcessGuardService AcessGuard { get; init; }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync("not implemented yet", cancellation: ct);
    }
}