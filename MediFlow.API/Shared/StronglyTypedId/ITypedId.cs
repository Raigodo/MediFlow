namespace MediFlow.API.Shared.StronglyTypedId;

public interface ITypedId
{
    Guid Value { get; init; }
}