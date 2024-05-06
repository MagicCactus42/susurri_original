using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using Susurri.Application.Time;
using Susurri.Core.Abstractions;
using Susurri.Core.DAL;

namespace Susurri.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAuthentication(o =>
        {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                // Tu wrzucic parametry po dodaniu miejsca na tokeny
                // https://www.youtube.com/watch?v=mgeuh8k3I4g  9:48 koniec
            };
        });

        services.AddAuthorization();
        services.AddScoped<IClock, Clock>();
        services.AddMudServices();
        services.AddServerSideBlazor().AddCircuitOptions(o => o.DetailedErrors = true);
        services.AddSignalR();
        services.AddPostgres();
        services.AddHttpClient();

        return services;
    }
}