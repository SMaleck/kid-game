using System;

namespace BehaviourTree.Nodes.Decorators
{
    public class InverterNode : IBehaviourTreeNode
    {
        private readonly IBehaviourTreeNode _node;

        public InverterNode(IBehaviourTreeNode node)
        {
            _node = node;
        }

        public NodeStatus Tick(double elapsedSeconds)
        {
            var result = _node.Tick(elapsedSeconds);
            switch (result)
            {
                case NodeStatus.Success:
                    return NodeStatus.Failure;

                case NodeStatus.Failure:
                    return NodeStatus.Success;

                default:
                    throw new ArgumentOutOfRangeException($"Invalid NodeStatus {result}");
            }
        }
    }
}
