using Susurri.Application.Abstractions;
using Susurri.Core.Entities;
using Susurri.Core.ValueObjects;

namespace Susurri.Api.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();
    
    public async Task<User> GetByIdAsync(UserId id)
    {
        await Task.CompletedTask;
        return _users.SingleOrDefault(x => x.Id == id);
    }

    public async Task<User> GetByUsernameAsync(Username username)
    {
        await Task.CompletedTask;
        return _users.SingleOrDefault(x => x.Username == username);
    }

    public async Task AddAsync(User user)
    {
        _users.Add(user);
        await Task.CompletedTask;
    }
}