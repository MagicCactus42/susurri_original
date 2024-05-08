using Susurri.Core.Abstractions;

namespace Susurri.Infrastructure.Time;

internal sealed class Clock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}
