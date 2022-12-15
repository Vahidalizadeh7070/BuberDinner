using System.Reflection;
using BuberDinner.Application.Common.Behaviors;
using BuberDinner.Application.Services.Authentication.Commands;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services){
        
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>)  
        );
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        // Use CQRS without any MediatR package 
        // services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        // services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        return services;
    }
}