using Game.Features.Savegames;
using Game.Features.Savegames.SavegameObjects;
using Game.Static.Locators;

namespace Game.Features.Player
{
    public class PlayerStateFeature : Feature
    {
        private SavegameFeature _savegameFeature;

        public bool IsPlayerLoaded => _savegameFeature.PlayerStorage != null;
        public PlayerStateSavegame Savegame { get; private set; }

        public string Id => Savegame.MetadataSavegame.Id;
        public string PlayerName => Savegame.MetadataSavegame.PlayerName;

        public PlayerStateFeature()
        {
        }

        public override void OnStart()
        {
            _savegameFeature = FeatureLocator.Get<SavegameFeature>();

            var lastPlayerId = _savegameFeature.GlobalStorage.Savegame.LastPlayerId;
            TryLoad(lastPlayerId);
        }

        public void Create(string playerName)
        {
            FeatureLocator.Get<SavegameFeature>().CreatePlayer(playerName);
        }

        public bool SwitchTo(string playerId)
        {
            return TryLoad(playerId);
        }

        private bool TryLoad(string playerId)
        {
            if (!string.IsNullOrWhiteSpace(playerId) &&
                _savegameFeature.TryLoadPlayer(playerId))
            {
                Savegame = _savegameFeature.PlayerStorage.Savegame;
                return true;
            }

            return false;
        }
    }
}
