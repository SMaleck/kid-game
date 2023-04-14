using Game.Utility;
using System;
using System.Collections.Generic;

namespace Game.Static.Locators
{
    public static class FeatureLocator
    {
        private static readonly Dictionary<Type, IFeature> Features = new(LocatorConst.FeatureCount);

        public static T Register<T>(IFeature feature) where T : IFeature
        {
            Features.Add(typeof(T), feature);
            return (T)feature;
        }

        public static IFeature Register(Type type, IFeature feature)
        {
            Features.Add(type, feature);
            return feature;
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

        public static T GetOrDefault<T>() where T : IFeature
        {
            var exists = Features.TryGetValue(typeof(T), out var feature);
            return exists ? (T)feature : default;
        }
    }
}
