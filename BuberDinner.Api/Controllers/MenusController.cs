using BuberDinner.Application.Menus.Command;
using BuberDinner.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _sender;

    public MenusController(IMapper mapper, IMediator sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        var createMenuResult = await _sender.Send(command);

        return createMenuResult.Match(menu => Ok(_mapper.Map<MenuResponse>(menu)),
        errors => Problem(errors)
        );

    }

}