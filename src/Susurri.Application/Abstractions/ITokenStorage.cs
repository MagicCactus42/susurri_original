using Susurri.Core.DTO;

namespace Susurri.Application.Abstractions;

public interface ITokenStorage
{
    void Set(JwtDto jwt);
    JwtDto Get();
}