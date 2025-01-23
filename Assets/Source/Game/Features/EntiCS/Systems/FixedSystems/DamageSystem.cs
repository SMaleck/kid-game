using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using Game.Features.EntiCS.Components.Tags;
using Game.Features.EntiCS.Systems.BaseSystems;
using System;

namespace Game.Features.EntiCS.Systems.LateSystems
{
    public class DamageSystem : PerEntitySystem
    {
        public override Type[] Filter { get; } =
        {
            typeof(PlayerTagComponent),
            typeof(ColliderComponent),
            typeof(LifecycleComponent)
        };

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            var lifecycle = entity.Get<LifecycleComponent>();
            if (!lifecycle.IsAlive)
            {
                return;
            }

            var collider = entity.Get<ColliderComponent>();
            for (var i = collider.Entered.Count - 1; i >= 0; i--)
            {
                var other = collider.Entered[i];
                if (!other.Entity.TryGet<DamageComponent>(out var damage))
                {
                    return;
                }

                switch (damage.Type)
                {
                    case DamageType.Amount:
                        lifecycle.Health -= damage.Amount;
                        break;

                    case DamageType.InstaKill:
                        lifecycle.Health = 0;
                        break;
                }

            }
        }
    }
}
