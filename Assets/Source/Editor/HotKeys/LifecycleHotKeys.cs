using System.Collections;
using Game.Utility;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace Source.Editor.HotKeys
{
    public static class LifecycleHotKeys
    {
        private const string GAME_SCENE_PATH = "Assets/Scenes/S_Root.unity";
        private const string PATH_TO_PREVIOUSLY_CLOSED_SCENE_KEY = "last-open-scene-path";
        
        [MenuItem(ProjectConst.MenuRoot + "Run game %l", false)]
        public static void RunGame()
        {
            if (!EditorApplication.isPlaying && !EditorApplication.isCompiling && EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                var currentScenePath = SceneManager.GetActiveScene().path;

                if (currentScenePath != GAME_SCENE_PATH)
                {
                    EditorPrefs.SetString(PATH_TO_PREVIOUSLY_CLOSED_SCENE_KEY, currentScenePath);
                }

                EditorSceneManager.OpenScene(GAME_SCENE_PATH);
                EditorApplication.isPlaying = true;
            }
        }

        [MenuItem(ProjectConst.MenuRoot + "Reopen last scene %#l", false)]
        public static void OpenPrevious()
        {
            var pathToPrevious = EditorPrefs.GetString(PATH_TO_PREVIOUSLY_CLOSED_SCENE_KEY);

            if (!string.IsNullOrEmpty(pathToPrevious))
            {
                var routine = StopPlayModeAndOpenScene(pathToPrevious);

                EditorApplication.CallbackFunction updateFunction = null;
                updateFunction = () =>
                {
                    if (!routine.MoveNext())
                    {
                        EditorApplication.update -= updateFunction;
                    }
                };

                EditorApplication.update += updateFunction;
            }
        }

        private static IEnumerator StopPlayModeAndOpenScene(string path)
        {
            EditorApplication.isPlaying = false;

            yield return null;

            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene(path);
            }
        }
    }
}
