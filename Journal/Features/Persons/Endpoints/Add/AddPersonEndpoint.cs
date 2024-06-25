using FastEndpoints;
using Journal.Data;
using Journal.Data.Repositories.Specifications;
using Journal.Domain.Persons;
using Journal.Domain.Persons.Services;
using Microsoft.EntityFrameworkCore;

namespace Journal.Features.Persons.Endpoints.Add;

public sealed class AddPersonEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("persons");
        AllowAnonymous();
    }

    public required IPersonRepository PersonRepository { get; set; }

    public override async Task HandleAsync(CancellationToken c)
    {
        await SendAsync("not implemented", cancellation: c);
    }
}