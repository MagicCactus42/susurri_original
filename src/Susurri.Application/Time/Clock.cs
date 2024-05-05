using Susurri.Core.Abstractions;

namespace Susurri.Application.Time;

internal sealed class Clock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}
