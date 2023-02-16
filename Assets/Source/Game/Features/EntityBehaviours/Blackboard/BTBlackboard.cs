using System.Collections.Generic;

namespace Game.Features.EntityBehaviours.Blackboard
{
    public class BTBlackboard
    {
        private readonly Dictionary<BTBlackboardKey, object> _blackBoardItems = new Dictionary<BTBlackboardKey, object>();

        public void Set<T>(BTBlackboardKey key, T value)
        {
            _blackBoardItems[key] = value;
        }

        public bool TryGet<T>(BTBlackboardKey key, out T value)
        {
            value = default;
            if (_blackBoardItems.TryGetValue(key, out var existing))
            {
                value = (T)existing;
                return true;
            }

            return false;
        }

        public bool TryConsume<T>(BTBlackboardKey key, out T value)
        {
            if (TryGet<T>(key, out value))
            {
                _blackBoardItems.Remove(key);
                return true;
            }

            return false;
        }

        public void RemoveSafe(BTBlackboardKey key)
        {
            if (_blackBoardItems.ContainsKey(key))
            {
                _blackBoardItems.Remove(key);
            }
        }

        public void Reset()
        {
            _blackBoardItems.Clear();
        }
    }
}
