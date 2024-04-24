using Microsoft.EntityFrameworkCore;
using Susurri.Client.Entities;

namespace Susurri.Client.Abstractions;

public interface ISusurriDbContext : IDisposable
{
    DbSet<ChatMessage> ChatMessages { get; }
    DbSet<User> Users { get; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
}