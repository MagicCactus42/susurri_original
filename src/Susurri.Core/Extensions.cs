using Microsoft.Extensions.DependencyInjection;
using Susurri.Core.Abstractions;
using Susurri.Core.DAL;
using Susurri.Core.DAL.Handlers;
using Susurri.Core.DTO;
using Susurri.Core.Queries;
using Susurri.Core.Services;

namespace Susurri.Core;


public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<ISusurriDbContext, SusurriDbContext>();
        services.AddTransient<IUserService, UserService>();
        services.AddScoped<IQueryHandler<GetUsers, IEnumerable<UserDto>>, GetUsersHandler>();
        services.AddTransient<IQueryHandler<GetUser, UserDto>, GetUserHandler>();
        
        return services;
    }
}