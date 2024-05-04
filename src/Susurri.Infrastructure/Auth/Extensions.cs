namespace Susurri.Client.Auth;

internal sealed class Extensions
{
    private const string SectionName = "auth";
    
    public static IServiceCollection AddAuth(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthOptions>(configuration.GetRequiredSection(SectionName));
        return services;
    }
}

