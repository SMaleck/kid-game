using System.Collections.Generic;

namespace Game.Utility.Extensions
{
    public static class CollectionExtensions
    {
        public static T GetRandom<T>(this T[] items)
        {
            var randomIndex = UnityEngine.Random.Range(0, items.Length);
            return items[randomIndex];
        }

        public static T GetRandom<T>(this List<T> items)
        {
            var randomIndex = UnityEngine.Random.Range(0, items.Count);
            return items[randomIndex];
        }
    }
}
