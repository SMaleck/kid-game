using EntiCS.Ticking;

namespace Game.Features.EntiCS.Systems.BaseSystems
{
    public abstract class PerEntityLateSystem : PerEntitySystem
    {
        public sealed override TickType UpdateType { get; } = TickType.LateUpdate;
    }
}
