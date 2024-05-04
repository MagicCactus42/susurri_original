using Susurri.Client.Abstractions;
using Susurri.Core.Abstractions;

namespace Susurri.Client.Time;

internal sealed class Clock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}
