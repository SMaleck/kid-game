using System;
using System.Collections.Generic;

namespace Game.Static.Locators
{
    public static class FeatureLocator
    {
        private static readonly Dictionary<Type, IFeature> Features = new();

        public static void Init()
        {
            Features.Clear();
        }

        public static T Register<T>(IFeature feature) where T : IFeature
        {
            Features[typeof(T)] = feature;
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
