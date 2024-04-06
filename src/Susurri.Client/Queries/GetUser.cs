using Susurri.Client.Abstractions;
using Susurri.Client.DTO;

namespace Susurri.Client.Queries;

public class GetUser : IQuery<UserDto>
{
    public Guid UserId { get; init; }
}