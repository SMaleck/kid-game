using BehaviourTree.Nodes;
using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using Game.Features.EntityBehaviours.Blackboard;
using UnityEngine;

namespace Game.Features.EntityBehaviours.Nodes
{
    public class UserInputNode : Node
    {
        private readonly JumpComponent _jumpComponent;

        public UserInputNode(IEntity entity, BTBlackboard blackboard)
            : base(entity, blackboard)
        {
            _jumpComponent = Entity.Get<JumpComponent>();
        }

        protected override NodeStatus OnTick(double elapsedSeconds)
        {
            return NodeStatus.Success;
        }
    }
}
