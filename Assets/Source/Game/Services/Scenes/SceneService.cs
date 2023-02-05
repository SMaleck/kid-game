using Game.Services.Scenes.Events;
using Game.Static.Events;
using Game.Utility;
using NPOI.SS.Formula.Functions;
using UnityEngine.SceneManagement;

namespace Game.Services.Scenes
{
    public class SceneService : Service
    {
        public UnityEngine.SceneManagement.Scene CurrentScene => SceneManager.GetActiveScene();
        public SceneId CurrentSceneId { get; private set; }

        private BeforeSceneSwitchEvent _currentSwitchEvent;

        public void To(SceneId sceneId)
        {
            _currentSwitchEvent = new BeforeSceneSwitchEvent(CurrentSceneId, sceneId);
            Log($"Starting Scene Load: [{_currentSwitchEvent.From}] -> [{_currentSwitchEvent.To}]");

            EventBus.Publish(new BeforeSceneUnloadEvent(CurrentSceneId));
            EventBus.Publish(_currentSwitchEvent);

            var sceneLoad = SceneManager.LoadSceneAsync((int)sceneId, LoadSceneMode.Additive);
            sceneLoad.completed += OnSceneLoadCompleted;
        }

        public void Quit()
        {
            EventBus.Publish(new BeforeQuitEvent());
            UnityEngine.Application.Quit();
        }

        private void OnSceneLoadCompleted(UnityEngine.AsyncOperation asyncOperation)
        {
            Log($"Scene Load Complete. Switching: [{_currentSwitchEvent.From}] -> [{_currentSwitchEvent.To}]");

            var fromScene = SceneManager.GetSceneByName(_currentSwitchEvent.From.ToSceneName());
            var toScene = SceneManager.GetSceneByName(_currentSwitchEvent.To.ToSceneName());

            SceneManager.UnloadSceneAsync(fromScene);
            SceneManager.SetActiveScene(toScene);

            CurrentSceneId = toScene.ToSceneId();
        }

        private void Log(string message)
        {
            GameLog.Log($"[{nameof(SceneService)}] {message}");
        }
    }
}
