using Microsoft.EntityFrameworkCore;
using Susurri.Client.Queries;
using Susurri.Client.DTO;
using Susurri.Client.ValueObjects;
using Susurri.Client.Abstractions;

namespace Susurri.Client.DAL.Handlers;

internal sealed class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
{
    private readonly SusurriDbContext _dbContext;

    public GetUsersHandler(SusurriDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query)
        => await _dbContext.Users
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();
}