using System;
using System.Collections.Generic;
using Game.Utility;

namespace Game.Static.Events
{
    public static class EventBus
    {
        private static readonly Dictionary<Type, List<Action<object>>> Actions = new();

        public static void OnEvent<TEvent>(Action<object> onEventAction)
        {
            if (!Actions.TryGetValue(typeof(TEvent), out var actions))
            {
                actions = new List<Action<object>>();
                Actions[typeof(TEvent)] = actions;
            }

            actions.Add(onEventAction);
        }

        public static void Unsubscribe(Action<object> onEventAction)
        {
            foreach (var actionList in Actions.Values)
            {
                for (var i = actionList.Count - 1; i >= 0; i--)
                {
                    if (actionList[i] == onEventAction)
                    {
                        actionList.RemoveAt(i);
                    }
                }
            }
        }

        public static void Publish<TEvent>(TEvent eventDto)
        {
            if (!Actions.TryGetValue(typeof(TEvent), out var actions))
            {
                return;
            }

            // Caching actions, because listeners can remove subscription in the action call
            // thus changing the length of the list. This can lead to actions being skipped
            var actionsCache = actions.ToArray();

            for (var i = 0; i < actionsCache.Length; i++)
            {
                var action = actionsCache[i];
                if (action?.Target == null)
                {
                    GameLog.Error($"[EventBus] Self-Cleaning Event Action for [{typeof(TEvent).Name}] on [{action?.Target}]");
                    actions.RemoveAt(i);
                    i--;
                    continue;
                }

                action.Invoke(eventDto);
            }
        }
    }
}
