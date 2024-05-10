using Susurri.Core.DTO;

namespace Susurri.Infrastructure.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, string role);
}