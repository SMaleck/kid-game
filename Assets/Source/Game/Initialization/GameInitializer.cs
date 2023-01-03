using Game.Utility;

namespace Game.Initialization
{
    public static class GameInitializer
    {
        public static bool IsInitialized { get; private set; }

        public static void Initialize()
        {
            if (IsInitialized)
            {
                GameLog.Warn($"{nameof(GameInitializer)} already initialized");
                return;
            }

            InitializeInternal();
            IsInitialized = true;
        }

        private static void InitializeInternal()
        {
        }
    }
}
