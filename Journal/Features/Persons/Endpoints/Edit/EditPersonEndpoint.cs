using FastEndpoints;

//namespace Journal.Features.Persons.Edit;

public sealed class EditPersonEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Patch("persons/{id}");
        AllowAnonymous();
    }


    public override async Task HandleAsync(CancellationToken c)
    {
        await SendAsync(new { Message = "Done" }, cancellation: c);
    }
}