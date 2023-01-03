using BehaviourTree.Nodes;
using BehaviourTree.Nodes.Decorators;
using BehaviourTree.Nodes.Structural;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BehaviourTree.Builder
{
    /// <summary>
    /// Fluent API for building a behaviour tree.
    /// </summary>
    public class BehaviourTreeBuilder
    {
        private readonly Stack<IStructuralNode> _structuralNodes = new Stack<IStructuralNode>();

        private bool _isFinalized;
        private IBehaviourTreeNode _currentNode;

        /// <summary>
        /// Adds a Sequence node.
        /// Sequence runs all child nodes until the last or the first FAILURE
        /// </summary>
        public BehaviourTreeBuilder Sequence()
        {
            AssertCanAddStructural();

            var node = new SequenceNode();
            SafeAddStructuralChild(node);

            return this;
        }

        /// <summary>
        /// Create a Sequence-If node.
        /// Sequence with a conditional node. Only runs the sequence if the condition is a SUCCESS
        /// </summary>
        public BehaviourTreeBuilder SequenceIf(IBehaviourTreeNode conditionalNode)
        {
            AssertCanAddStructural();
            AssertNode(conditionalNode);

            var node = new SequenceIfNode(conditionalNode);
            SafeAddStructuralChild(node);

            return this;
        }

        /// <summary>
        /// Create a Parallel node.
        /// Parallel runs all child nodes, regardless of status and returns FAILURE if at least 1 failed
        /// </summary>
        public BehaviourTreeBuilder Parallel()
        {
            AssertCanAddStructural();

            var node = new ParallelNode();
            SafeAddStructuralChild(node);

            return this;
        }

        /// <summary>
        /// Create a selector node.
        /// Selector runs all child nodes until the first SUCCESS
        /// </summary>
        public BehaviourTreeBuilder Selector()
        {
            AssertCanAddStructural();

            var node = new SelectorNode();
            SafeAddStructuralChild(node);

            return this;
        }

        /// <summary>
        /// Create an action node. Must have a StructuralNode parent
        /// </summary>
        public BehaviourTreeBuilder Do(IBehaviourTreeNode node)
        {
            AssertCanAddLeaf();

            _structuralNodes.Peek().AddChild(node);

            return this;
        }

        /// <summary>
        /// Create a decorated action node, that will always fail.
        /// Must have a StructuralNode parent
        /// </summary>
        public BehaviourTreeBuilder DoAsFailure(IBehaviourTreeNode node)
        {
            AssertCanAddLeaf();

            var decorator = new AsFailureNode(node);
            _structuralNodes.Peek().AddChild(decorator);

            return this;
        }

        /// <summary>
        /// Create a decorated action node, that will always succeed.
        /// Must have a StructuralNode parent
        /// </summary>
        public BehaviourTreeBuilder DoAsSuccess(IBehaviourTreeNode node)
        {
            AssertCanAddLeaf();

            var decorator = new AsSuccessNode(node);
            _structuralNodes.Peek().AddChild(decorator);

            return this;
        }

        /// <summary>
        /// Splice a sub tree into the parent tree.
        /// </summary>
        public BehaviourTreeBuilder Splice(BehaviourTree subTree)
        {
            AssertCanAddSubTree(subTree);

            _structuralNodes.Peek().AddChild(subTree.StartNode);

            return this;
        }

        /// <summary>
        /// Ends a sequence of children.
        /// </summary>
        public BehaviourTreeBuilder End()
        {
            AssertIsMutable();

            _currentNode = _structuralNodes.Pop();
            return this;
        }

        /// <summary>
        /// Finalize Tree. No more modes can be added afterwards
        /// </summary>
        public BehaviourTree Build()
        {
            AssertCanBuild();

            _isFinalized = true;
            return new BehaviourTree(_currentNode);
        }

        private void AssertCanAddStructural([CallerMemberName] string name = "node")
        {
            AssertIsMutable(name);
        }

        private void AssertCanAddLeaf([CallerMemberName] string name = "node")
        {
            AssertIsMutable(name);

            if (_structuralNodes.Count <= 0)
            {
                throw new InvalidOperationException("Can't create an unnested ActionNode, it must be a leaf node.");
            }
        }

        private void AssertCanAddSubTree(BehaviourTree subTree)
        {
            if (subTree == null)
            {
                throw new InvalidOperationException("Cannot splice NULL tree");
            }
            if (subTree.StartNode == null)
            {
                throw new InvalidOperationException("Cannot splice tree with NULL StartNode");
            }
            if (_structuralNodes.Count <= 0)
            {
                throw new InvalidOperationException("Can't splice an unnested sub-tree, there must be a parent-tree.");
            }
        }

        private void AssertIsMutable([CallerMemberName] string name = "node")
        {
            if (_isFinalized)
            {
                throw new InvalidOperationException($"Cannot add {name} to finalized tree");
            }
        }

        private void AssertCanBuild()
        {
            if (_currentNode == null)
            {
                throw new InvalidOperationException("Can't create a behaviour tree with zero nodes");
            }

            if (_structuralNodes.Count > 0)
            {
                throw new InvalidOperationException($"Cannot build tree from non-root node. Did you forget to call {nameof(End)}()?");
            }
        }

        private void AssertNode(IBehaviourTreeNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
        }

        private void SafeAddStructuralChild(IStructuralNode child)
        {
            if (_structuralNodes.Count > 0)
            {
                _structuralNodes.Peek().AddChild(child);
            }

            _structuralNodes.Push(child);
        }
    }
}
