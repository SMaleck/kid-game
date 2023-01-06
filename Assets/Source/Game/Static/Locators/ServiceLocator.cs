using System;
using System.Collections.Generic;

namespace Game.Static.Locators
{
    public static class ServiceLocator
    {
        // ToDo [OPTIMIZATION] Determine a more fitting initial capacity
        // This could be done by a small editor tool inspecting the respective types or initializer
        private static readonly Dictionary<Type, IService> Services = new(16);

        public static void Register<T>(IService service) where T : IService
        {
            Services.Add(typeof(T), service);
        }

        public static void Remove<T>() where T : IService
        {
            if (Services.ContainsKey(typeof(T)))
            {
                Services.Remove(typeof(T));
            }
        }

        public static T Get<T>() where T : IService
        {
            return (T)Services[typeof(T)];
        }
    }
}
