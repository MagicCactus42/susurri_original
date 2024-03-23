using Microsoft.EntityFrameworkCore;

namespace Susurri.Client.DAL
{
    public static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services)
        {
            const string connectionString = "Host=localhost;Database=Susurri;Username=postgres;Password=";
            services.AddDbContext<SusurriDbContext>(options => options.UseNpgsql(connectionString));
            
            return services;
        }
    }
}