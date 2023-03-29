using UnityEngine;

namespace Game.Utility
{
    public class ScreenConst
    {
        public static Rect SafeArea => Screen.safeArea;
        public static Rect ScreenRect => new Rect(0, 0, Screen.width, Screen.height);

        public static float TopSafeAreaHeight => ScreenRect.yMax - SafeArea.yMax;
        public static float BottomSafeAreaHeight => SafeArea.yMin - ScreenRect.yMin;
        public static float LeftSafeAreaWidth => SafeArea.xMin - ScreenRect.xMin;
        public static float RightSafeAreaWidth => ScreenRect.xMax - SafeArea.xMax;
    }
}
