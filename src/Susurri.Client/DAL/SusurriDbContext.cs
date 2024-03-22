using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Susurri.Client.Hubs;

namespace Susurri.Client.DAL;

public class SusurriDbContext : DbContext
{
    public DbSet<IChatClient> iChatClient;

    public SusurriDbContext(DbContextOptions<SusurriDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }
}