using Game.Features.GameWorld.Levels;
using Game.Static.Locators;
using Game.Utility;
using UnityEngine;

namespace Game.Debug
{
    public class DebugHud : MonoBehaviour
    {
        private LevelStateFeature _levelState;

        private GUIStyle _style;
        private GUIStyle Style => _style ??= CreateGUIStyle();

        private void Start()
        {
            _levelState = FeatureLocator.Get<LevelStateFeature>();
        }

        private static GUIStyle CreateGUIStyle()
        {
            var style = new GUIStyle
            {
                normal = { textColor = new Color(0.0f, 1.0f, 0.0f, 0.7f) },
                alignment = TextAnchor.UpperLeft
            };
            var h = Screen.height;
            style.fontSize = h * 2 / 100;

            return style;
        }

        private void OnGUI()
        {
            int w = Screen.width, h = Screen.height;
            var safeAreaHeight = ScreenConst.TopSafeAreaHeight / ScreenConst.ScreenRect.height * Screen.height;

            var cornerOffset = h * 2 / 200;
            var rect = new Rect(cornerOffset, cornerOffset + safeAreaHeight, w, h * 2f / 100);

            GUI.Label(rect, GetProgress(), Style);
        }

        private string GetProgress()
        {
            var progressPercent = _levelState?.RelativeProgress ?? 0;
            return $"{progressPercent:P}";
        }
    }
}
