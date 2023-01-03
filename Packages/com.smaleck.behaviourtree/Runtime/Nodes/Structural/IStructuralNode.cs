namespace BehaviourTree.Nodes.Structural
{
    public interface IStructuralNode : IBehaviourTreeNode
    {
        void AddChild(IBehaviourTreeNode node);
    }
}
