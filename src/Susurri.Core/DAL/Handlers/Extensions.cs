using Susurri.Core.DTO;
using Susurri.Core.Entities;

namespace Susurri.Core.DAL.Handlers;

public static class Extensions
{
    public static UserDto AsDto(this User entity)
        => new()
        {
            Id = entity.Id,
            Username = entity.Username
        };
}