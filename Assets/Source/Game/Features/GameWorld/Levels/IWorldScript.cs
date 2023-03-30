using System;

namespace Game.Features.GameWorld.Levels
{
    public interface IWorldScript
    {
        event Action OnComplete;
        void RunScript();
    }
}
