using EntiCS.Entities;
using Game.Features.EntiCS.Utility;

namespace Game.Features.EntiCS.Components.Generic
{
    public interface ISensorTarget : IResettable
    {
        IEntity Entity { get; }
    }
}
