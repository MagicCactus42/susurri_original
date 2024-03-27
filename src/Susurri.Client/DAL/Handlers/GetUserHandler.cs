using Microsoft.EntityFrameworkCore;
using Susurri.Client.Queries;
using Susurri.Client.DTO;
using Susurri.Client.ValueObjects;
using Susurri.Client.Abstractions;

namespace Susurri.Client.DAL.Handlers;

internal sealed class GetUserHandler : IQueryHandler<GetUser, UserDto>
{
    private readonly SusurriDbContext _dbContext;
    
    public GetUserHandler(SusurriDbContext dbContext)
        => _dbContext = dbContext;
    
    public async Task<UserDto> HandleAsync(GetUser query)
    {
        var userId = new UserId(query.UserId);
        var user = await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == userId);

        return user?.AsDto();
    }
}