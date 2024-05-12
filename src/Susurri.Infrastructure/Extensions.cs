using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Susurri.Core.Abstractions;
using Susurri.Infrastructure.Abstractions;
using Susurri.Infrastructure.Commands;
using Susurri.Infrastructure.Commands.Handlers;
using Susurri.Infrastructure.Security;
using Susurri.Infrastructure.Time;
using Susurri.Infrastructure.Auth;
using Susurri.Infrastructure.Exceptions;


namespace Susurri.Infrastructure;


public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IClock, Clock>();
        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddScoped(typeof(ICommandHandler<SignUp>), typeof(SignUpHandler));
        services.AddScoped(typeof(ICommandHandler<SignIn>), typeof(SignInHandler));
        services.AddScoped<ExceptionMiddleware>();
        services.AddSecurity();
        services.AddHttpContextAccessor();
        services.AddAuth(configuration);
        
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
    
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}