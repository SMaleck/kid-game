using BehaviourTree.Nodes;
using EntiCS.Entities;
using Game.Features.EntiCS.Components.Generic;

namespace Game.Features.EntityBehaviours.Nodes
{
    public class AssertIsRunningNode : Node
    {
        protected ILifecycleComponent _lifecycle;

        public AssertIsRunningNode(IEntity entity) : base(entity)
        {
            _lifecycle = Entity.Get<ILifecycleComponent>();
        }

        protected override NodeStatus OnTick(double elapsedSeconds)
        {
            return _lifecycle.IsAlive ? NodeStatus.Success : NodeStatus.Failure;
        }
    }
}
