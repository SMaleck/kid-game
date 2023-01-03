using System;
using System.Collections.Generic;

namespace Game.Static.Locators
{
    public static class DataLocator
    {
        private static readonly Dictionary<Type, IData> DataSources = new();

        public static void Register(IData data)
        {
            DataSources[data.GetType()] = data;
        }

        public static T Get<T>() where T : IData
        {
            return (T)DataSources[typeof(T)];
        }
    }
}
