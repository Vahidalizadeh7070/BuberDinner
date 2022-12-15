using BuberDinner.Domain.Common.Calculations;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReviews.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnersId> _dinnersId = new();
    private readonly List<MenuReviewsId> _menuReviewsId = new();
    public string Name { get; }
    public string Description { get; }
    public AverageRating Average { get; }
    //public float Average { get; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; }
    public IReadOnlyList<DinnersId> DinnersIds => _dinnersId.AsReadOnly();
    public IReadOnlyList<MenuReviewsId> MenuReviewsIds => _menuReviewsId.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Menu(MenuId menuId, string name, string description,  List<MenuSection> sections, HostId hostId, DateTime createdDateTime, DateTime updatedDateTime) : base(menuId)
    {
        
        Name = name;
        Description = description;
        _sections = sections;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(string name, string description, HostId hostId, List<MenuSection> sections)
    {
        return new (MenuId.CreateUnique(), name, description, sections,hostId,DateTime.UtcNow, DateTime.UtcNow);
    }
}