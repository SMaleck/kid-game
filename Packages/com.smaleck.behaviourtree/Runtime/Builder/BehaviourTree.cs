using BehaviourTree.Nodes;

namespace BehaviourTree.Builder
{
    public class BehaviourTree
    {
        public IBehaviourTreeNode StartNode { get; }

        public BehaviourTree(IBehaviourTreeNode startNode)
        {
            StartNode = startNode;
        }

        public NodeStatus Tick(float elapsedSeconds)
        {
            return StartNode.Tick(elapsedSeconds);
        }
    }
}
