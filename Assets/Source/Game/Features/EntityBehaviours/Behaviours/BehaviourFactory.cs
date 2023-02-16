using BehaviourTree.Builder;
using BehaviourTree.Nodes;
using EntiCS.Entities;
using Game.Features.EntityBehaviours.Blackboard;
using Game.Features.EntityBehaviours.Nodes;
using Game.Features.Ticking;
using Game.Static.Locators;

namespace Game.Features.EntityBehaviours.Behaviours
{
    public abstract class BehaviourFactory
    {
        protected IEntity _entity;
        protected BTBlackboard _blackboard;

        public IEntityBehaviour Create(IEntity entity)
        {
            _entity = entity;
            _blackboard = new BTBlackboard();

            var behaviour = new EntityBehaviour(
                entity,
                CreateTree(),
                FeatureLocator.Get<TickerFeature>().SceneTicker);

            _entity = null;

            return behaviour;
        }

        protected abstract BehaviourTree.Builder.BehaviourTree CreateTree();

        protected BehaviourTreeBuilder Builder()
        {
            return new BehaviourTreeBuilder();
        }
        
        protected IBehaviourTreeNode AssertIsRunning()
        {
            return new AssertIsRunningNode(_entity, _blackboard);
        }
        
        protected IBehaviourTreeNode UserInput()
        {
            return new UserInputNode(_entity, _blackboard);
        }
    }
}
