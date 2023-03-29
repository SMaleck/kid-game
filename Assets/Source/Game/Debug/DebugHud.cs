using Game.Features.GameWorld.Levels;
using Game.Static.Locators;
using Game.Utility;
using System.Text;
using UnityEngine;

namespace Game.Debug
{
    public class DebugHud : MonoBehaviour
    {
        private LevelStateFeature _levelState;
        private readonly FpsProfiler _fpsProfiler = new FpsProfiler();
        private readonly StringBuilder _sb = new StringBuilder();

        private GUIStyle _style;
        private GUIStyle Style => _style ??= CreateGUIStyle();

        private void Start()
        {
            _levelState = FeatureLocator.Get<LevelStateFeature>();
        }

        private void Update()
        {
            _fpsProfiler.OnUpdate();
        }

        private static GUIStyle CreateGUIStyle()
        {
            var style = new GUIStyle
            {
                normal = { textColor = new Color(0.0f, 1.0f, 0.0f, 0.7f) },
                alignment = TextAnchor.UpperLeft,
                fontSize = 36
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

            GUI.Label(rect, GetDebugString(), Style);
        }

        private string GetDebugString()
        {
            return _sb.Clear()
                .AppendLine(GetFPS())
                .AppendLine(GetProgress())
                .ToString();
        }

        private string GetProgress()
        {
            var progressPercent = _levelState?.RelativeProgress ?? 0;
            return $"{progressPercent:P}";
        }

        private string GetFPS()
        {
            return $"FPS {_fpsProfiler.CurrentFps} | AVG {_fpsProfiler.AverageFps} | MIN {_fpsProfiler.MinFps} | MAX {_fpsProfiler.MaxFps}";
        }
    }
}
