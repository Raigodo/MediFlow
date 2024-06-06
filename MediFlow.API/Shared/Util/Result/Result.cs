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
}

public class Result<T>
{
    private Result(T value, Error error, bool isSuccess)
    {
        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public Error Error { get; }
    public T Value { get; }

    public static Result<T> Success(T value) => new(value, Error.None, true);
    public static Result<T> Failure(Error error) => new(default, error, false);
}