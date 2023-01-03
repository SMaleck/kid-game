using EntiCS.Ticking;

namespace Game.Features.EntiCS.Systems.BaseSystems
{
    public abstract class PerEntityFixedSystem : PerEntitySystem
    {
        public sealed override TickType UpdateType { get; } = TickType.FixedUpdate;
    }
}
