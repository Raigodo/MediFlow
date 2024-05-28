namespace MediFlow.API.Shared;

public static class ResponseExtensions
{
    public static ValueTask<IResult> ToValueTask(this IResult result) => ValueTask.FromResult(result);
}
