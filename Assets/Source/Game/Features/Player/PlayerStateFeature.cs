using Game.Features.Savegames;
using Game.Static.Locators;
using System.Linq;

namespace Game.Features.Player
{
    public class PlayerStateFeature : Feature
    {
        private SavegameFeature _savegameFeature;

        public bool IsPlayerLoaded => FeatureLocator.Get<SavegameFeature>().PlayerStorage != null;

        public PlayerStateFeature()
        {
        }

        public override void OnStart()
        {
            _savegameFeature = FeatureLocator.Get<SavegameFeature>();

            var players = _savegameFeature.GlobalStorage.Savegame.PlayerSavegames
                .FirstOrDefault();

            if (players != null)
            {
                _savegameFeature.TryLoadPlayer(players.Id);
            }
        }

        public void Create(string playerName)
        {
            FeatureLocator.Get<SavegameFeature>().CreatePlayer(playerName);
        }
    }
}
