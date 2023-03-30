using EntiCS.Entities.Components;
using Game.Features.EntiCS.Utility;
using System.Collections.Generic;

namespace Game.Features.EntiCS.Components
{
    // ToDo Is this component still needed?
    public enum PlayerEffectType
    {
        JumpStart,
        JumpApex,
        JumpEnd
    }

    public class PlayerEventQueueComponent : EntityComponent, IResettable
    {
        public Queue<PlayerEffectType> Queue { get; set; } = new Queue<PlayerEffectType>();

        public void ResetState()
        {
            Queue.Clear();
        }
    }
}
