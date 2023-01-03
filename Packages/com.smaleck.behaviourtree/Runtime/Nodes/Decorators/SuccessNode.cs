namespace BehaviourTree.Nodes.Decorators
{
    public class SuccessNode : IBehaviourTreeNode
    {
        public NodeStatus Tick(double elapsedSeconds)
        {
            return NodeStatus.Success;
        }
    }
}
