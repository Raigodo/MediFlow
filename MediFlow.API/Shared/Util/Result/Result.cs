namespace MediFlow.API.Shared.Util.Result;

public sealed class Result
{
    private Result(Error error)
    {
        IsSuccess = error == Error.None;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result Success() => new(Error.None);
    public static Result Failure(Error error) => new(error);

    public static implicit operator Result(Error error) => new(error);
}
