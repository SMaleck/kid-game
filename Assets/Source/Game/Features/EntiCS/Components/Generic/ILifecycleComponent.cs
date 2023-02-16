using EntiCS.Entities.Components;

namespace Game.Features.EntiCS.Components.Generic
{
    public interface ILifecycleComponent : IEntityComponent
    {
        bool IsAlive { get; set; }
    }
}
