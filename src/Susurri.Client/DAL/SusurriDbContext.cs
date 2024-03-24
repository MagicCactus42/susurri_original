using Microsoft.EntityFrameworkCore;
using MudBlazor.Extensions;
using Susurri.Client.Entities;
using Susurri.Client.Hubs;

namespace Susurri.Client.DAL;

internal sealed class SusurriDbContext : DbContext
{
    public DbSet<ChatMessage>? ChatMessage { get; set; }

    public SusurriDbContext() {}
    public SusurriDbContext(DbContextOptions<SusurriDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}