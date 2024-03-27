using Susurri.Client.DTO;
using Susurri.Client.Entities;

namespace Susurri.Client.DAL.Handlers;

public static class Extensions
{
    public static UserDto AsDto(this User entity)
        => new()
        {
            Id = entity.Id,
            Username = entity.Username
        };
}