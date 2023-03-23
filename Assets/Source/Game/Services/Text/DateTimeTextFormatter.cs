using System;

namespace Game.Services.Text
{
    public class DateTimeTextFormatter
    {
        public string Duration(double seconds)
        {
            return Duration(TimeSpan.FromSeconds(seconds));
        }

        public string Duration(TimeSpan duration)
        {
            var hours = Math.Floor(duration.TotalHours);
            return $"{hours}:{duration.Minutes}:{duration.Seconds}";
        }

        public string Timestamp(DateTime timestamp)
        {
            return $"{timestamp.Day}. {timestamp.Month}. {timestamp.Year} - {timestamp.Hour}:{timestamp.Minute}";
        }
    }
}
