using EntiCS.Entities;
using Game.Features.EntiCS.Components.Render;
using Game.Features.EntiCS.Components.Tags;
using Game.Features.EntiCS.Systems.BaseSystems;
using Game.Features.LevelSelection;
using Game.Static.Locators;
using System;

namespace Game.Features.EntiCS.Systems.RenderSystems
{
    public class PlayerEffectRenderSystem : PerEntitySystem
    {
        public override Type[] Filter { get; } = new[]
        {
            typeof(PlayerTagComponent),
            typeof(PlayerEffectRenderComponent),
            typeof(SpecialEffectQueueComponent)
        };

        private readonly bool _canPlayApex;

        public PlayerEffectRenderSystem()
        {
            var levelSelect = FeatureLocator.Get<LevelSelectFeature>();
            _canPlayApex = levelSelect.Complexity <= LevelComplexity.C0;
        }

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            var effects = entity.Get<PlayerEffectRenderComponent>();
            var eventQueue = entity.Get<SpecialEffectQueueComponent>();

            if (eventQueue.Effects.Contains(SpecialEffectType.JumpStart))
            {
                effects.JumpStartSE.Play();
            }
            if (_canPlayApex && eventQueue.Effects.Contains(SpecialEffectType.JumpApex))
            {
                effects.JumpApexSE.Play();
            }
            if (eventQueue.Effects.Contains(SpecialEffectType.JumpEnd))
            {
                effects.JumpEndSE.Play();
            }
        }
    }
}
