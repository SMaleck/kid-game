using System.Collections.Generic;
using Game.Features.Player;
using Game.Features.Savegames;
using Game.Features.Ticking;
using Game.Static.Locators;
using Game.Utility;

namespace Game.Initialization
{
    public static class GameInitializer
    {
        private static readonly List<IFeature> RegisteredFeatures = new();

        public static bool IsInitialized { get; private set; }
        public static bool IsStarted { get; private set; }

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
            RegisterFeature<SavegameFeature>(new SavegameFeature());
            RegisterFeature<SavegameAutoSaveFeature>(new SavegameAutoSaveFeature());
            RegisterFeature<PlayerStateFeature>(new PlayerStateFeature());
            RegisterFeature<TickerFeature>(new TickerFeature());
        }

        public static void Start()
        {
            if (IsStarted)
            {
                GameLog.Warn($"{nameof(GameInitializer)} already started");
                return;
            }

            foreach (var feature in RegisteredFeatures)
            {
                feature.OnStart();
            }

            IsStarted = true;
        }

        private static void RegisterFeature<T>(IFeature feature) where T : IFeature
        {
            RegisteredFeatures.Add(feature);
            FeatureLocator.Register<T>(feature);
        }
    }
}
