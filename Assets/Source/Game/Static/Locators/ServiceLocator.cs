using System;
using System.Collections.Generic;

namespace Game.Static.Locators
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, IService> Services = new();

        public static void Register<T>(IService service) where T : IService
        {
            Services[typeof(T)] = service;
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
