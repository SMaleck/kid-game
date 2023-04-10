using EntiCS.Entities.Components;
using Game.Features.EntiCS.Utility;
using UnityEngine;

namespace Game.Features.EntiCS.Components.Render
{
    public class PlayerEffectRenderComponent : EntityComponent
    {
        [field: SerializeField] public SpecialEffect JumpStartSE { get; private set; }
        [field: SerializeField] public SpecialEffect JumpApexSE { get; private set; }
        [field: SerializeField] public SpecialEffect JumpEndSE { get; private set; }
    }
}
