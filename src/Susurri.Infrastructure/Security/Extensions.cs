using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Susurri.Application.Abstractions;
using Susurri.Core.Abstractions;
using Susurri.Core.Entities;

namespace Susurri.Infrastructure.Security;

internal static class Extensions
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddSingleton<IPasswordManager, PasswordManager>();

        return services;
    }
}