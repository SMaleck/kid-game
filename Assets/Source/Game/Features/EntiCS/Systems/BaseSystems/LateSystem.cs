using EntiCS.Systems;
using EntiCS.Ticking;

namespace Game.Features.EntiCS.Systems.BaseSystems
{
    public abstract class LateSystem : EntitySystem
    {
        public sealed override TickType UpdateType { get; } = TickType.LateUpdate;
    }
}
