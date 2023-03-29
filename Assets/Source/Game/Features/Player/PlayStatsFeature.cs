using Game.Features.GameWorld.Levels;
using Game.Services.Scenes.Events;
using Game.Services.Time;
using Game.Static.Events;
using Game.Static.Locators;
using System;

namespace Game.Features.Player
{
    public class PlayStatsFeature : Feature
    {
        private PlayerStateFeature _playerStateFeature;
        private LevelStateFeature _levelStateFeature;
        private TimeService _timeService;
        private DateTime _startedAt;

        public override void OnStart()
        {
            _playerStateFeature = FeatureLocator.Get<PlayerStateFeature>();
            _levelStateFeature = FeatureLocator.Get<LevelStateFeature>();
            _timeService = ServiceLocator.Get<TimeService>();

            _startedAt = _timeService.NowUtc;
            _levelStateFeature.OnComplete += RecordPlaytime;

            EventBus.OnEvent<BeforeQuitEvent>(_ => RecordPlaytime());
            EventBus.OnEvent<EndSceneEvent>(_ => RecordPlaytime());
        }

        private void RecordPlaytime()
        {
            var playtime = _timeService.NowUtc - _startedAt;
            _startedAt = _timeService.NowUtc;

            _playerStateFeature.Savegame.MetadataSavegame.TotalPlayTimeTicks += playtime.Ticks;
        }
    }
}
