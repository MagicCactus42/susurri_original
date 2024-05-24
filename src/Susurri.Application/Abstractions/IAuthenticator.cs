using Susurri.Core.DTO;

namespace Susurri.Application.Abstractions;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, string username, string role);
}