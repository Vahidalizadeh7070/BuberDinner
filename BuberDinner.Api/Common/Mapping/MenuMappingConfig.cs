using BuberDinner.Application.Menus.Command;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Menu;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

using MenuSection = BuberDinner.Domain.Menu.Entities.MenuSection;
using MenuItem = BuberDinner.Domain.Menu.Entities.MenuItem;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest request, string hostId), CreateMenuCommand>()
        .Map(dest => dest.HostId, src => src.hostId)
        .Map(dest => dest, src => src.request);

        config.NewConfig<Menu, MenuResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.AverageRating, src => src.Average.Value)
        .Map(dest => dest.HostId, src => src.HostId.Value)
        .Map(dest => dest.DinnerIds, src => src.DinnersIds.Select(dinnerId => dinnerId.Value))
        .Map(dest => dest.MenuReviewIds, src => src.MenuReviewsIds.Select(menuReviewId => menuReviewId.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);
    }
}