namespace BehaviourTree.Nodes.Decorators
{
    public class FailureNode : IBehaviourTreeNode
    {
        public NodeStatus Tick(double elapsedSeconds)
        {
            return NodeStatus.Failure;
        }
    }
}
