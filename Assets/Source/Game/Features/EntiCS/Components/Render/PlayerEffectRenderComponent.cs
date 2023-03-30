using EntiCS.Entities.Components;
using Game.Features.EntiCS.Utility;
using UnityEngine;

namespace Game.Features.EntiCS.Components.Render
{
    public class PlayerEffectRenderComponent : EntityComponent
    {
        [field: SerializeField] public ParticleSystem JumpApexPS { get; set; }
        [field: SerializeField] public Transform JumpApexSlot { get; set; }

        [field: SerializeField] public ParticleSystem DustPS { get; set; }
        [field: SerializeField] public Transform DustSlot { get; set; }

        private ParticleSystemPool _apexPool;
        private ParticleSystemPool ApexPool => _apexPool ??= new ParticleSystemPool(JumpApexPS);

        private ParticleSystemPool _dustPool;
        private ParticleSystemPool DustPool => _dustPool ??= new ParticleSystemPool(DustPS);
        
        public void PlayJumpApex()
        {
            ApexPool.Spawn(JumpApexSlot.position);
        }

        public void PlayDust()
        {
            DustPool.Spawn(DustSlot.position);
        }
    }
}
