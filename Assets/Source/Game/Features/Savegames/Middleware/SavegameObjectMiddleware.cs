using Game.Features.Savegames.Data;
using Savegames.Middleware;

namespace Game.Features.Savegames.Middleware
{
    public abstract class SavegameObjectMiddleware<TSave> : ISavegameObjectMiddleware
        where TSave : class
    {
        public virtual int Order => SavegameConstants.DefaultMiddlewareOrder;
        public virtual ObjectMiddlewareStage Stage => ObjectMiddlewareStage.OnSave_BeforeSerialization;

        public void Process<T>(T savegame)
        {
            if (savegame is TSave == false)
            {
                return;
            }

            ProcessInternal(savegame as TSave);
        }

        protected abstract void ProcessInternal(TSave savegame);
    }
}
