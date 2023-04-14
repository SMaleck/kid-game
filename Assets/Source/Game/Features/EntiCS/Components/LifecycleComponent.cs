using EntiCS.Entities.Components;
using Game.Features.EntiCS.Components.Generic;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class LifecycleComponent : EntityComponent, ILifecycleComponent
    {
        [field: SerializeField] public bool IsAlive { get; set; } = true;
    }
}
