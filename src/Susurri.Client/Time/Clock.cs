using Susurri.Client.Abstractions;

namespace Susurri.Client.Time;

internal sealed class Clock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}
