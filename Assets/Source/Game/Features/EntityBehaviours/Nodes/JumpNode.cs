using BehaviourTree.Nodes;
using EntiCS.Entities;

namespace Game.Features.EntityBehaviours.Nodes
{
    public class JumpNode : Node
    {
        public JumpNode(IEntity entity) : base(entity)
        {
        }

        protected override NodeStatus OnTick(double elapsedSeconds)
        {
            return NodeStatus.Success;
        }
    }
}
