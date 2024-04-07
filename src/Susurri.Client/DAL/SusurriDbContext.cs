using Microsoft.EntityFrameworkCore;
using Susurri.Client.Entities;

namespace Susurri.Client.DAL;

internal sealed class SusurriDbContext : DbContext
{
    public DbSet<ChatMessage> ChatMessage { get; init; }
    public DbSet<User> Users { get; init; }

    public SusurriDbContext() {}
    public SusurriDbContext(DbContextOptions<SusurriDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}