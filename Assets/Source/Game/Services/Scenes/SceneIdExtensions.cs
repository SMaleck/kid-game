using System;

namespace Game.Services.Scenes
{
    public static class SceneIdExtensions
    {
        public const string SceneNamePrefix = "S_";

        public static string ToSceneName(this SceneId sceneId)
        {
            return $"{SceneNamePrefix}{sceneId.ToString()}";
        }

        public static SceneId ToSceneId(this string sceneName)
        {
            var cleanedName = sceneName.Replace(SceneNamePrefix, string.Empty);
            return Enum.Parse<SceneId>(cleanedName);
        }

        public static SceneId ToSceneId(this UnityEngine.SceneManagement.Scene scene)
        {
            var cleanedName = scene.name.Replace(SceneNamePrefix, string.Empty);
            return Enum.Parse<SceneId>(cleanedName);
        }

        public static bool IsLevelScene(this SceneId sceneId)
        {
            return sceneId >= SceneId.Level;
        }
    }
}
