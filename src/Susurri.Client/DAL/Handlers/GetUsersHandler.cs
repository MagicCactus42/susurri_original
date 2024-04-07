using Microsoft.EntityFrameworkCore;
using Susurri.Client.Queries;
using Susurri.Client.DTO;
using Susurri.Client.ValueObjects;
using Susurri.Client.Abstractions;

namespace Susurri.Client.DAL.Handlers;

internal sealed class GetUsersHandler(SusurriDbContext dbContext) : IQueryHandler<GetUsers, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query)
        => await dbContext.Users
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();
}