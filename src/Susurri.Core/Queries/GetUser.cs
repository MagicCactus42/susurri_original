using Susurri.Core.Abstractions;
using Susurri.Core.DTO;

namespace Susurri.Core.Queries;

public class GetUser : IQuery<UserDto>
{
    public Guid UserId { get; init; }
}