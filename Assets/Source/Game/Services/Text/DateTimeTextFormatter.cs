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
            return $"{hours}:{duration.Minutes:00}:{duration.Seconds:00}";
        }

        public string Timestamp(DateTime timestamp)
        {
            return $"{timestamp.Day:00}. {timestamp.Month:00}. {timestamp.Year:00} - {timestamp.Hour}:{timestamp.Minute:00}";
        }
    }
}
