namespace Game.Utility.Extensions
{
    public static class CollectionExtensions
    {
        public static T GetRandom<T>(this T[] array)
        {
            var randomIndex = UnityEngine.Random.Range(0, array.Length);
            return array[randomIndex];
        }
    }
}
