using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}