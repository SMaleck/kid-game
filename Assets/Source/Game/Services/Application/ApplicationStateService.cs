using UnityEngine;

namespace Game.Services.Application
{
    public class ApplicationStateService : Service
    {
        private ApplicationStateMonoProxy _monoProxy;

        public bool IsPaused => _monoProxy.IsPaused;
        public bool IsFocused => _monoProxy.IsFocused;

        public ApplicationStateService()
        {
            _monoProxy = new GameObject(nameof(ApplicationStateMonoProxy))
                .AddComponent<ApplicationStateMonoProxy>();

            UnityEngine.Object.DontDestroyOnLoad(_monoProxy);

            _monoProxy.RegisterActions(
                OnApplicationPause,
                OnApplicationFocus);
        }

        private void OnApplicationPause(bool isPaused)
        {
        }

        private void OnApplicationFocus(bool isFocused)
        {
        }
    }
}
