using Game.Features.Savegames.SavegameObjects;
using Game.Services.Time;
using Game.Static.Locators;

namespace Game.Features.Savegames.Middleware
{
    public class PlayerStateSavegameObjectMiddleware : SavegameObjectMiddleware<PlayerStateSavegame>
    {
        protected override void ProcessInternal(PlayerStateSavegame savegame)
        {
            savegame.MetadataSavegame.UpdatedAtUtc = ServiceLocator.Get<TimeService>().NowUtc;
        }
    }
}
