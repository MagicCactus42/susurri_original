using Microsoft.EntityFrameworkCore;
using Susurri.Core.Abstractions;
using Susurri.Core.DTO;
using Susurri.Core.Queries;

namespace Susurri.Core.DAL.Handlers;

internal sealed class GetUsersHandler(SusurriDbContext dbContext) : IQueryHandler<GetUsers, IEnumerable<UserDto>>
{
    private readonly SusurriDbContext _dbContext = dbContext;

    public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query)
        => await _dbContext.Users
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();
}