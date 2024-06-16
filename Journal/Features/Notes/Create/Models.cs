using FastEndpoints;
using FluentValidation;

namespace Journal.Features.Notes.Create;

public record JournalRequest(string Input)
{


}

public sealed class RequestValidator : Validator<JournalRequest>
{
    public RequestValidator()
    {
        RuleFor(x => x.Input)
            .NotNull().NotEmpty().WithMessage("Input not specified! >:(");
    }
}

public record JournalResponse(string Message);
