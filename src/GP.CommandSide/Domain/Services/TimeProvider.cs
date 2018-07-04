using GP.CommandSide.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.CommandSide.Domain.Services
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;

        public DateTime Today => DateTime.Today;
    }
}
