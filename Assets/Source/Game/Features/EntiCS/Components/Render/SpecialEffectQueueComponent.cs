using EntiCS.Entities.Components;
using Game.Features.EntiCS.Utility;
using System.Collections.Generic;

namespace Game.Features.EntiCS.Components.Render
{
    public enum SpecialEffectType
    {
        JumpStart,
        JumpApex,
        JumpEnd,
        Kill
    }

    public class SpecialEffectQueueComponent : EntityComponent, IResettable
    {
        public HashSet<SpecialEffectType> Effects { get; set; } = new();

        public void Add(SpecialEffectType effect)
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
