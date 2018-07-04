using System;

namespace GP.CommandSide.Domain.Abstractions
{
    public interface ITimeProvider
    {
        DateTime UtcNow { get; }
        DateTime Today { get; }
    }
}
