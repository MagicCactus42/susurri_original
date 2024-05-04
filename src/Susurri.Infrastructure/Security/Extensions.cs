using Microsoft.AspNetCore.Identity;
using Susurri.Client.Abstractions;
using Susurri.Core.Entities;

namespace Susurri.Client.Security;

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