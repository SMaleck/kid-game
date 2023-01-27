using System;

namespace Game.Utility.Extensions
{
    // ToDo [PACKAGE] Move to General Utils package
    public static class NumberExtensions
    {
        public static int Clamp(this int value, int min, int max)
        {
            value = Math.Max(min, value);
            value = Math.Min(max, value);

            return value;
        }

        public static float Clamp(this float value, float min, float max)
        {
            value = Math.Max(min, value);
            value = Math.Min(max, value);

            return value;
        }

        public static double Clamp(this double value, double min, double max)
        {
            value = Math.Max(min, value);
            value = Math.Min(max, value);

            return value;
        }
    }
}
