using EntiCS;
using EntiCS.Entities;
using EntiCS.Systems;
using EntiCS.World;
using EntiCS.WorldManagement;
using Game.Features.EntiCS.Systems;
using Game.Features.EntiCS.Systems.LateSystems;
using Game.Features.Ticking;
using Game.Static.Locators;

namespace Game.Features.EntiCS
{
    public class EnticsFeature : Feature
    {
        public IEntiCSRunner Runner { get; }
        public IWorld World => Runner.World;

        public EnticsFeature()
        {
            var ticker = FeatureLocator.Get<TickerFeature>();
            Runner = EntiCSFactory.CreateRunner(ticker.Ticker);

            Runner.AddSystems(new IEntitySystem[]
            {
                new MovementSystem(),
                new RunStatsSystem()
            });
        }

        public void AddEntity(IEntity entity)
        {
            World.Add(entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            World.Remove(entity);
        }

        public override void OnEnd()
        {
            Runner.Dispose();
        }
    }
}
