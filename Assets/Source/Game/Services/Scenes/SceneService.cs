using Game.Services.Scenes.Events;
using Game.Static.Events;
using UnityEngine.SceneManagement;

namespace Game.Services.Scenes
{
    public class SceneService : Service
    {
        public UnityEngine.SceneManagement.Scene CurrentScene => SceneManager.GetActiveScene();
        public SceneId CurrentSceneId { get; private set; }

        public void To(SceneId sceneId)
        {
            EventBus.Publish(new BeforeSceneUnloadEvent(CurrentSceneId));
            EventBus.Publish(new BeforeSceneSwitchEvent(CurrentSceneId, sceneId));

            var sceneLoad = SceneManager.LoadSceneAsync((int)sceneId);
            sceneLoad.completed += OnSceneLoadCompleted;
        }

        public void Quit()
        {
            EventBus.Publish(new BeforeQuitEvent());
            UnityEngine.Application.Quit();
        }

        private void OnSceneLoadCompleted(UnityEngine.AsyncOperation asyncOperation)
        {
            CurrentSceneId = CurrentScene.ToSceneId();
        }
    }
}
