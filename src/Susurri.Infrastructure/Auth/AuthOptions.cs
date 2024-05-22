namespace Susurri.Infrastructure.Auth;

public class AuthOptions
{
    public string UniqueName { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SigningKey { get; set; }
    public TimeSpan? Expiry { get; set; }
}