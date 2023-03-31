using Game.Features.EntiCS.Utility;
using System.Collections.Generic;
using EntiCS.Entities.Components;

namespace Game.Features.EntiCS.Components.Generic
{
    public interface ISensorComponent : IEntityComponent, IResettable
    {
        IReadOnlyList<ISensorTarget> Known { get; }
        IReadOnlyList<ISensorTarget> Entered { get; }
        IReadOnlyList<ISensorTarget> Exited { get; }

        void Clean();
    }
}
