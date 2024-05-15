using Microsoft.EntityFrameworkCore;
using Susurri.Application.Abstractions;
using Susurri.Core.Abstractions;
using Susurri.Core.DTO;
using Susurri.Core.Entities;
using Susurri.Core.ValueObjects;

namespace Susurri.Api.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly List<User> _users = [];
    private readonly ISusurriDbContext _dbContext;

    public UserRepository(ISusurriDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetByIdAsync(UserId id)
    {
        await Task.CompletedTask;
        return _dbContext.Users.SingleOrDefault(x => x.Id == id);
    }

    public async Task<User> GetByUsernameAsync(Username username)
    {
        await Task.CompletedTask;
        return _dbContext.Users.SingleOrDefault(x => x.Username == username);
    }

    public async Task<UserDto> GetInfoByUsernameAsync(Username username)
    {
        var userEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);

        if (userEntity == null)
        {
            return null;
        }
        
        var userDto = new UserDto
        {
            Id = userEntity.Id,
            Username = userEntity.Username
        };
        return userDto;
    }

    public async Task AddAsync(User user)
    {
        _dbContext.Users.Add(user);
        await Task.CompletedTask;
    }
    
}