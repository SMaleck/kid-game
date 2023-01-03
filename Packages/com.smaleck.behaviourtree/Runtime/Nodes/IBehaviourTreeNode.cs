namespace BehaviourTree.Nodes
{
    public interface IBehaviourTreeNode
    {
        NodeStatus Tick(double elapsedSeconds);
    }
}
