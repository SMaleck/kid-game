using System.Collections.Generic;

namespace BehaviourTree.Nodes.Structural
{
    public class SelectorNode : IStructuralNode
    {
        private readonly List<IBehaviourTreeNode> _nodes;

        public SelectorNode(params IBehaviourTreeNode[] nodes)
        {
            _nodes = new List<IBehaviourTreeNode>(nodes);
        }

        public NodeStatus Tick(double elapsedSeconds)
        {
            NodeStatus lastStatus = NodeStatus.Success;

            foreach (var node in _nodes)
            {
                lastStatus = node.Tick(elapsedSeconds);
                if (lastStatus == NodeStatus.Success)
                {
                    return lastStatus;
                }
            }

            return lastStatus;
        }

        public void AddChild(IBehaviourTreeNode node)
        {
            _nodes.Add(node);
        }
    }
}
