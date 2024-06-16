using FastEndpoints;
using FluentValidation;

namespace Journal.Features.Notes.Create;

public record CreateNoteRequest(string Input)
{
    public sealed class RequestValidator : Validator<CreateNoteRequest>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Input)
                .NotNull().NotEmpty().WithMessage("Input not specified! >:(");
        }
    }
}
