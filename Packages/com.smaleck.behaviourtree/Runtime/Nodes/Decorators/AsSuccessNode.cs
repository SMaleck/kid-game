namespace BehaviourTree.Nodes.Decorators
{
    public class AsSuccessNode : IBehaviourTreeNode
    {
        private readonly IBehaviourTreeNode _node;

        public AsSuccessNode(IBehaviourTreeNode node)
        {
            _node = node;
        }

        public NodeStatus Tick(double elapsedSeconds)
        {
            _node.Tick(elapsedSeconds);
            return NodeStatus.Success;
        }
    }
}
