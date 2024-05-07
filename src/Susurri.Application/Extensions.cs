using MudBlazor.Services;
using Susurri.Application.Time;
using Susurri.Core.Abstractions;
using Susurri.Core.DAL;

namespace Susurri.Application;

public static class Extensions
{
    public static Task Main()
    {
        return null;
    }
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IClock, Clock>();
        services.AddMudServices();
        services.AddServerSideBlazor().AddCircuitOptions(o => o.DetailedErrors = true);
        services.AddSignalR();
        services.AddPostgres();
        services.AddHttpClient();

        return services;
    }
}