using Game.Features.Savegames.SavegameObjects;

namespace Game.Features.Player
{
    public class PlayerState : Feature
    {
        public GlobalSavegame Savegame;
        public PlayerMetadataSavegame CurrentPlayerSavegame;

        public PlayerState()
        {

        }
    }
}
