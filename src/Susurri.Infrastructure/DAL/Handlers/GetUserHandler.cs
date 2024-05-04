using Microsoft.EntityFrameworkCore;
using Susurri.Client.Queries;
using Susurri.Client.DTO;
using Susurri.Client.Abstractions;
using Susurri.Core.ValueObjects;

namespace Susurri.Client.DAL.Handlers;

internal sealed class GetUserHandler(SusurriDbContext dbContext) : IQueryHandler<GetUser, UserDto>
{
    public async Task<UserDto> HandleAsync(GetUser query)
    {
        var userId = new UserId(query.UserId);
        var user = await dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == userId);

        return user?.AsDto();
    }
}