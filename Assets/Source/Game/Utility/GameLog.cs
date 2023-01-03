using System;
using System.Diagnostics;

namespace Game.Utility
{
    public static class GameLog
    {
        [Conditional("DEBUG")]
        public static void Log(object message)
        {
            UnityEngine.Debug.Log(message);
        }

        [Conditional("DEBUG")]
        public static void Warn(object message)
        {
            UnityEngine.Debug.LogWarning(message);
        }

        [Conditional("DEBUG")]
        public static void Error(object message)
        {
            UnityEngine.Debug.LogError(message);
        }

        [Conditional("DEBUG")]
        public static void Error(object message, Exception e)
        {
            UnityEngine.Debug.LogError($"{message.ToString()}\n{e.ToString()}");
        }
    }
}
