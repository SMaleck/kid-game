using Game.Features.Savegames.SavegameObjects;
using Game.Services.ClientInfo;
using Game.Services.Time;
using Game.Static.Locators;

namespace Game.Features.Savegames.Middleware
{
    public class GlobalSavegameObjectMiddleware : SavegameObjectMiddleware<GlobalSavegame>
    {
        protected override void ProcessInternal(GlobalSavegame savegame)
        {
            savegame.MetadataSavegame.UpdatedAtUtc = ServiceLocator.Get<TimeService>().NowUtc;

            var clientInfo = ServiceLocator.Get<ClientInfoService>();
            savegame.MetadataSavegame.ClientVersion = clientInfo.Version;
            savegame.MetadataSavegame.Platform = clientInfo.Platform;
        }
    }
}
