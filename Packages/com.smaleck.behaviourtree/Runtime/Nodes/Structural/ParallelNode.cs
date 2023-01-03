using System.Collections.Generic;

namespace BehaviourTree.Nodes.Structural
{
    public class ParallelNode : IStructuralNode
    {
        private readonly List<IBehaviourTreeNode> _nodes;

        public ParallelNode(params IBehaviourTreeNode[] nodes)
        {
            _nodes = new List<IBehaviourTreeNode>(nodes);
        }

        public NodeStatus Tick(double elapsedSeconds)
        {
            var failureCount = 0;
            
            foreach (var node in _nodes)
            {
                var status = node.Tick(elapsedSeconds);
                failureCount = failureCount + (status == NodeStatus.Failure ? 1 : 0);
            }

            return failureCount <= 0 ? NodeStatus.Success : NodeStatus.Failure;
        }

        public void AddChild(IBehaviourTreeNode node)
        {
            _nodes.Add(node);
        }
    }
}
