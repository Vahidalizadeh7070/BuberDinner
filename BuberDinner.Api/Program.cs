using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation()
                    .AddApplication()
                    .AddInfrastructure(builder.Configuration);

    // If we want to use Filter attribute for error handling 
    // we should use AddControllers() method like below code
    //builder.Services.AddControllers( options => options.Filters.Add<ErrorHandlingFilterAttribute>());
}

var app = builder.Build();
{
    // Middleware approach for error handling.
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
