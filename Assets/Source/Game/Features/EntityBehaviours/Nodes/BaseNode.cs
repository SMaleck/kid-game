using BehaviourTree.Nodes;
using EntiCS.Entities;
using Game.Features.EntityBehaviours.Blackboard;

namespace Game.Features.EntityBehaviours.Nodes
{
    public abstract class Node : IBehaviourTreeNode
    {
        protected IEntity Entity { get; }
        protected BTBlackboard Blackboard { get; }

        protected Node(IEntity entity, BTBlackboard blackboard)
        {
            Entity = entity;
            Blackboard = blackboard;
        }

        public NodeStatus Tick(double elapsedSeconds)
        {
            return OnTick(elapsedSeconds);
        }

        protected abstract NodeStatus OnTick(double elapsedSeconds);
    }
}
