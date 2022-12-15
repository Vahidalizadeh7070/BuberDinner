
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    public static readonly List<Menu> _menus = new();
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}