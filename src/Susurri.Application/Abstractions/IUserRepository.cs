using Susurri.Core.Entities;
using Susurri.Core.ValueObjects;

namespace Susurri.Application.Abstractions;

public interface IUserRepository
{
    Task<User> GetByIdAsync(UserId id);
    Task<User> GetByUsernameAsync(Username username);
    Task AddAsync(User user);
}