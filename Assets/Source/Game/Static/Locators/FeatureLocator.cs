using System;
using System.Collections.Generic;

namespace Game.Static.Locators
{
    public static class FeatureLocator
    {
        // ToDo [OPTIMIZATION] Determine a more fitting initial capacity
        // This could be done by a small editor tool inspecting the respective types or initializer
        private static readonly Dictionary<Type, IFeature> Features = new(32);

        public static void Init()
        {
            Features.Clear();
        }

        public static T Register<T>(IFeature feature) where T : IFeature
        {
            Features.Add(typeof(T), feature);
            return (T)feature;
        }

        public static void Remove<T>() where T : IFeature
        {
            Remove(typeof(T));
        }

        public static void Remove(Type featureType)
        {
            if (Features.ContainsKey(featureType))
            {
                Features.Remove(featureType);
            }
        }

        public static T Get<T>() where T : IFeature
        {
            return (T)Features[typeof(T)];
        }
    }
}
