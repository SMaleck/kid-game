using BehaviourTree.Nodes;
using EntiCS.Entities;

namespace Game.Features.EntityBehaviours.Nodes
{
    public abstract class Node : IBehaviourTreeNode
    {
        protected IEntity Entity { get; }

        protected Node(IEntity entity)
        {
            Entity = entity;
        }

        public NodeStatus Tick(double elapsedSeconds)
        {
            return OnTick(elapsedSeconds);
        }

        protected abstract NodeStatus OnTick(double elapsedSeconds);
    }
}
