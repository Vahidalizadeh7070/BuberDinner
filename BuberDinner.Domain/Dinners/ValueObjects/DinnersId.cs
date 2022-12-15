using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Dinners.ValueObjects;

public sealed class DinnersId : ValueObject
{
    public Guid Value { get; }
    private DinnersId(Guid value)
    {
        Value = value;
    }

    public static DinnersId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}