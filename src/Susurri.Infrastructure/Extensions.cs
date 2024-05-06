using Microsoft.Extensions.DependencyInjection;
using Susurri.Core.Abstractions;
using Susurri.Infrastructure.Abstractions;
using Susurri.Infrastructure.Commands;
using Susurri.Infrastructure.Commands.Handlers;
using Susurri.Infrastructure.Security;

namespace Susurri.Infrastructure;


public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddScoped(typeof(ICommandHandler<SignUp>), typeof(SignUpHandler));
        services.AddSecurity();
        return services;
    }
}