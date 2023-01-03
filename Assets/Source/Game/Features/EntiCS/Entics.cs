using EntiCS;
using EntiCS.Entities;
using EntiCS.Systems;
using EntiCS.Ticking;
using EntiCS.World;
using EntiCS.WorldManagement;
using Game.Features.EntiCS.Systems;
using Game.Features.EntiCS.Systems.LateSystems;

namespace Game.Features.EntiCS
{
    public class Entics : Feature
    {
        public IEntiCSRunner Runner { get; }
        public ITicker Ticker => Runner.Ticker;
        public IWorld World => Runner.World;

        public Entics()
        {
            Runner = EntiCSFactory.CreateRunner();

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
    }
}
