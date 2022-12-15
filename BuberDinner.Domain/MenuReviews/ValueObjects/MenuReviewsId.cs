using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.MenuReviews.ValueObjects;

public sealed class MenuReviewsId : ValueObject
{
    public Guid Value { get; }
    private MenuReviewsId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewsId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}