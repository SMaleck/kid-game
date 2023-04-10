using EntiCS.Entities.Components;
using Game.Features.EntiCS.Utility;
using System.Collections.Generic;

namespace Game.Features.EntiCS.Components.Render
{
    public enum PlayerEffectType
    {
        JumpStart,
        JumpApex,
        JumpEnd
    }

    public class PlayerEventQueueComponent : EntityComponent, IResettable
    {
        public HashSet<PlayerEffectType> Effects { get; set; } = new();

        public void Add(PlayerEffectType effect)
        {
            Effects.Add(effect);
        }

        public void ResetState()
        {
            Effects.Clear();
        }

        public void Clean()
        {
            ResetState();
        }
    }
}
