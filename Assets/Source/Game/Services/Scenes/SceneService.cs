using Game.Services.Scenes.Events;
using Game.Static.Events;
using Game.Utility;

namespace Game.Services.Scenes
{
    public class SceneService : Service
    {
        public SceneId CurrentSceneId => SceneManagerProxy.CurrentSceneId;

        public SceneService()
        {
            SceneManagerProxy.Init();
        }

        public void InitialLoad()
        {
            if (SceneManagerProxy.SceneCount > 1 ||
                SceneManagerProxy.CurrentSceneId != SceneId.Root)
            {
                Error($"Initial Load can only be performed when game is still in the root scene. Scene: {CurrentSceneId}");
                return;
            }

            SceneManagerProxy.LoadAndSwitchScene(SceneId.Title, false, ObjectConst.DefaultAction);
        }

        public void ToTitle()
        {
            SceneManagerProxy.LoadAndSwitchScene(SceneId.Title, true, ObjectConst.DefaultAction);
        }

        public void ToHub()
        {
            SceneManagerProxy.LoadAndSwitchScene(SceneId.HubWorld, true, ObjectConst.DefaultAction);
        }

        public void ToLevel()
        {
            SceneManagerProxy.LoadAndSwitchScene(SceneId.Level, true, ObjectConst.DefaultAction);
        }

        public void ReloadLevel()
        {
            if (!CurrentSceneId.IsLevelScene())
            {
                Error($"Current scene is not a level. Current: [{CurrentSceneId}]");
                return;
            }

            SceneManagerProxy.ReloadCurrent();
        }

        public void Quit()
        {
            EventBus.Publish(new BeforeQuitEvent());
            UnityEngine.Application.Quit();
        }

        private void Log(string message)
        {
            GameLog.Log($"[{nameof(SceneService)}] {message}");
        }

        private void Error(string message)
        {
            GameLog.Error($"[{nameof(SceneService)}] {message}");
        }
    }
}
