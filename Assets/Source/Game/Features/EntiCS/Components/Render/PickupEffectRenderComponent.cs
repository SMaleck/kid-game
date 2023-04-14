using EntiCS.Entities.Components;
using Game.Features.EntiCS.Utility;
using UnityEngine;

namespace Game.Features.EntiCS.Components.Render
{
    public class PickupEffectRenderComponent : EntityComponent
    {
        [field: SerializeField] public SpecialEffect PickupSE { get; private set; }
    }
}
