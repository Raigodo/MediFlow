namespace MediFlow.API.Shared.Util.Result;

public sealed class ErrorOr<T>
{
    private ErrorOr(T value, Error error, bool isSuccess)
    {
        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public Error Error { get; }
    public T Value { get; }

    public static ErrorOr<T> Success(T value) => new(value, Error.None, true);
    public static ErrorOr<T> Failure(Error error) => new(default, error, false);

    public R Match<R>(
            Func<T, R> success,
            Func<Error, R> failure) =>
        IsSuccess ? success(Value) : failure(Error);

    public static implicit operator ErrorOr<T>(T value) => ErrorOr<T>.Success(value);
    public static implicit operator ErrorOr<T>(Error error) => ErrorOr<T>.Failure(error);
}