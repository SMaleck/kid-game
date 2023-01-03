namespace BehaviourTree.Nodes.Structural
{
    public class SequenceIfNode : IStructuralNode
    {
        private readonly IBehaviourTreeNode _condition;
        private readonly SequenceNode _sequence;

        public SequenceIfNode(IBehaviourTreeNode condition, params IBehaviourTreeNode[] nodes)
        {
            _condition = condition;
            _sequence = new SequenceNode(nodes);
        }

        public NodeStatus Tick(double elapsedSeconds)
        {
            var conditionStatus = _condition.Tick(elapsedSeconds);
            if (conditionStatus == NodeStatus.Failure)
            {
                return conditionStatus;
            }

            return _sequence.Tick(elapsedSeconds);
        }

        public void AddChild(IBehaviourTreeNode node)
        {
            _sequence.AddChild(node);
        }
    }
}
