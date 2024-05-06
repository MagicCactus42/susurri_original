using Microsoft.EntityFrameworkCore;
using Susurri.Core.Abstractions;
using Susurri.Core.DTO;
using Susurri.Core.Queries;

namespace Susurri.Core.DAL.Handlers;

internal sealed class GetUsersHandler(SusurriDbContext dbContext) : IQueryHandler<GetUsers, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query)
        => await dbContext.Users
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();
}