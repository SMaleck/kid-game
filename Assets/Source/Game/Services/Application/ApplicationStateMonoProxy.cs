using System;
using UnityEngine;

namespace Game.Services.Application
{
    internal class ApplicationStateMonoProxy : MonoBehaviour
    {
        private Action<bool> _onApplicationPause;
        private Action<bool> _onApplicationFocus;

        public bool IsPaused { get; private set; } = false;
        public bool IsFocused { get; private set; } = true;

        public void RegisterActions(
            Action<bool> onApplicationPause,
            Action<bool> onApplicationFocus)
        {
            _onApplicationPause = onApplicationPause;
            _onApplicationFocus = onApplicationFocus;
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void OnApplicationPause(bool isPaused)
        {
            IsPaused = isPaused;
            _onApplicationPause.Invoke(isPaused);
        }

        private void OnApplicationFocus(bool isFocused)
        {
            IsFocused = isFocused;
            _onApplicationFocus.Invoke(isFocused);
        }
    }
}
