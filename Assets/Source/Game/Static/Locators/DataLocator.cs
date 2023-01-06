using System;
using System.Collections.Generic;

namespace Game.Static.Locators
{
    public static class DataLocator
    {
        // ToDo [OPTIMIZATION] Determine a more fitting initial capacity
        // This could be done by a small editor tool inspecting the respective types or initializer
        private static readonly Dictionary<Type, IData> DataSources = new(32);

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
