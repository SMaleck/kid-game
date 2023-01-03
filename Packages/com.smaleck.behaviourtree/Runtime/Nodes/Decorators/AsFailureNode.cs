namespace BehaviourTree.Nodes.Decorators
{
    public class AsFailureNode : IBehaviourTreeNode
    {
        private readonly IBehaviourTreeNode _node;

        public AsFailureNode(IBehaviourTreeNode node)
        {
            _node = node;
        }

        public NodeStatus Tick(double elapsedSeconds)
        {
            _node.Tick(elapsedSeconds);
            return NodeStatus.Failure;
        }
    }
}
