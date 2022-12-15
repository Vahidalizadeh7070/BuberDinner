using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId menuSectionId, string name, string description, List<MenuItem> items) : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public static MenuSection Craete(string name, string description, List<MenuItem> items){
        return new(MenuSectionId.CreateUnique(), name, description, items);
    }
}