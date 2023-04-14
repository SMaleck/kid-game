using System;
using System.Collections.Generic;
using Game.Utility;

namespace Game.Static.Locators
{
    public static class DataLocator
    {
        private static readonly Dictionary<Type, IData> DataSources = new(LocatorConst.DataCount);

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
