using Susurri.Application.Abstractions;
using Susurri.Application.DTO;
using Susurri.Client.Abstractions;

namespace Susurri.Application.Queries;

public class GetUser : IQuery<UserDto>
{
    public Guid UserId { get; init; }
}