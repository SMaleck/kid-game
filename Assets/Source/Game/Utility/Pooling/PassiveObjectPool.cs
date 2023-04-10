using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Utility.Pooling
{
    public class PassiveObjectPool<T> where T : Component
    {
        private readonly T _prefab;
        private readonly Func<T, bool> _isFreePredicate;

        private readonly List<T> _free = new();
        private readonly List<T> _active = new();

        public PassiveObjectPool(T prefab, Func<T, bool> isFreePredicate)
        {
            _prefab = prefab;
            _isFreePredicate = isFreePredicate;
        }

        public T Spawn()
        {
            var instance = GetOrCreate();
            _active.Add(instance);

            return instance;
        }

        private T GetOrCreate()
        {
            SanitizeActive();

            if (_free.Count > 0)
            {
                var instance = _free[0];
                _free.RemoveAt(0);

                return instance;
            }

            return Create();
        }

        private T Create()
        {
            var instance = GameObject.Instantiate<T>(_prefab);
            return instance;
        }

        private void SanitizeActive()
        {
            for (var i = _active.Count - 1; i >= 0; i--)
            {
                var instance = _active[i];
                if (_isFreePredicate(instance))
                {
                    _free.Add(instance);
                    _active.RemoveAt(i);
                }
            }
        }
    }
}
