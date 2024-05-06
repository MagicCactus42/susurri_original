using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Susurri.Core.DAL;

public static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services)
    {
        const string connectionString = "Host=localhost;Database=postgres;Username=postgres;Password=DtMMaNtC44i4";
        services.AddDbContext<SusurriDbContext>(options => options.UseNpgsql(connectionString));
            
        return services;
    }
}