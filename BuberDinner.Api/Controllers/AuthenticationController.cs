using BuberDinner.Api.Filters;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using BuberDinner.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using MapsterMapper;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
// [ErrorHandlingFilter]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    // CQRS without MediatR

    // private readonly IAuthenticationCommandService authenticationCommandService;
    // private readonly IAuthenticationQueryService authenticationQueryService;
    // public AuthenticationController(
    //     IAuthenticationCommandService _authenticationCommandService,
    //     IAuthenticationQueryService _authenticationQueryService
    //     )
    // {
    //     authenticationCommandService = _authenticationCommandService;
    //     authenticationQueryService = _authenticationQueryService;
    // }

    // Inject MediatR
    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }



    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);
        
        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }
        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }


    // Map AuthenticationResult to AuthenticationResponse

    // private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    // {
    //     return new AuthenticationResponse(
    //         authResult.user.Id,
    //         authResult.user.FirstName,
    //         authResult.user.LastName,
    //         authResult.user.Email,
    //         authResult.Token
    //     );
    // }
}