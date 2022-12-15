using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Command;

public record CreateMenuCommand(
    string Name,
    string Description, 
    string HostId,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;


public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items
);

public record MenuItemCommand(
    string Name,
    string Description
);