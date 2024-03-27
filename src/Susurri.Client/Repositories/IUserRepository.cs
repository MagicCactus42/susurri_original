using Susurri.Client.Entities;
using Susurri.Client.ValueObjects;

namespace Susurri.Client.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(UserId id);
    Task<User> GetByUsernameAsync(Username username);
    Task AddAsync(User user);
}