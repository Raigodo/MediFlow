using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MediFlow.API.Shared.StronglyTypedId;

public class TypedIdConverter<T> : ValueConverter<T, string> where T : ITypedId, new()
{
    public TypedIdConverter() : base(
        id => id.Value.ToString(),
        str => new() { Value = Guid.Parse(str) })
    {

    }
}
