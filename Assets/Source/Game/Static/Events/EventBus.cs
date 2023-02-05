using System;
using System.Collections.Generic;

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

            for (var i = 0; i < actions.Count; i++)
            {
                var action = actions[i];
                if (action == null)
                {
                    actions.RemoveAt(i);
                    i--;
                    continue;
                }

                action.Invoke(eventDto);
            }
        }
    }
}
