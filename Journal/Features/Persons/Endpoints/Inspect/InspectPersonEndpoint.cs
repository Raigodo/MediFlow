using FastEndpoints;
using Journal.Data.Repositories.Specifications;
using Journal.Domain.Persons.Services;
using Journal.Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace Journal.Features.Persons.Endpoints.Inspect;

public sealed class InspectPersonEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("persons/{id}");
        AllowAnonymous();
    }

    public required IPersonRepository PersonRepository { get; set; }

    public override async Task HandleAsync(CancellationToken c)
    {
        var person = await PersonRepository
            .GetFirstAsync(new ExperimentlPersonSpecification());
        await SendAsync(person, cancellation: c);
    }
}

record Response(int x);

class ExperimentlPersonSpecification : ISpecification<Person, Response>
{
    public IQueryable<Person> ApplyFiltering(IQueryable<Person> query) => query;

    public IQueryable<Person> ApplyJoining(IQueryable<Person> query) => query.Include(p => p.Notes);

    public IQueryable<Response> ApplyMapping(IQueryable<Person> query)
    {
        return query.Select(p => new Response(p.Notes.Count()));
    }
    public IQueryable<Person> ApplyOrdering(IQueryable<Person> query) => query;
}
