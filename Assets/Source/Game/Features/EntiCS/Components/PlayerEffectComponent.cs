using EntiCS.Entities.Components;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class PlayerEffectComponent : EntityComponent
    {
        [field: SerializeField] public ParticleSystem JumpApexPS { get; set; }
        [field: SerializeField] public ParticleSystem JumpStartPS { get; set; }
        [field: SerializeField] public ParticleSystem JumpEndPS { get; set; }
    }
}
