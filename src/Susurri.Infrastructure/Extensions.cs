using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Susurri.Core.Abstractions;
using Susurri.Infrastructure.Abstractions;
using Susurri.Infrastructure.Commands;
using Susurri.Infrastructure.Commands.Handlers;
using Susurri.Infrastructure.Security;
using Susurri.Infrastructure.Time;
using Susurri.Infrastructure.Auth;


namespace Susurri.Infrastructure;


public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IClock, Clock>();
        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddScoped(typeof(ICommandHandler<SignUp>), typeof(SignUpHandler));
        services.AddSecurity();
        services.AddAuth(configuration);
        
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<Exception>();
        app.UseAuthentication();
        app.MapControllers();

        return app;
    }
}