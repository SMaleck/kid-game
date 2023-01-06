using System;

namespace Game.Services.Time
{
    public class TimeService : Service
    {
        public DateTime Now => DateTime.Now;
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
