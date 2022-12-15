using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Command;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;
    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var menu = Menu.Create(hostId: HostId.CreateUnique(), name: request.Name,
        description: request.Description,
        sections: request.Sections.ConvertAll(section=> MenuSection.Craete(section.Name,section.Description,section.Items.ConvertAll(item=>MenuItem.Create(item.Name,item.Description)))));

        _menuRepository.Add(menu);
        return menu;
    }
}
