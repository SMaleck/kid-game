using Game.Features.Player.Savegames;

namespace Game.Features.Player
{
    public class PlayerState : Feature
    {
        public GlobalSavegame Savegame;
        public PlayerSavegame CurrentPlayerSavegame;

        public PlayerState()
        {

        }
    }
}
