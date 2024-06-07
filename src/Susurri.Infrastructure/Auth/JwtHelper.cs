using System.IdentityModel.Tokens.Jwt;

namespace Susurri.Infrastructure.Auth;

public static class JwtHelper
{
    public static string GetUsernameFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
        var username = jwtToken?.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.UniqueName)?.Value;

        return username;
    }
}