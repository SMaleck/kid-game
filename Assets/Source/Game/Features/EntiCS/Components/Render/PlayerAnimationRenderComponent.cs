using EntiCS.Entities.Components;
using Game.Features.EntiCS.Utility;
using UnityEngine;

namespace Game.Features.EntiCS.Components.Render
{
    public class PlayerAnimationRenderComponent : EntityComponent, IResettable
    {
        private static class Hashes
        {
            public static int EndWin = Animator.StringToHash("EndWin");
            public static int EndLost = Animator.StringToHash("EndLost");
            public static int Velocity = Animator.StringToHash("Velocity");
            public static int Hammer = Animator.StringToHash("Hammer");
            public static int Die = Animator.StringToHash("Die");
            public static int Jump = Animator.StringToHash("Jump");
        }

        [SerializeField] private Animator _animator;

        public int Velocity { set => _animator.SetInteger(Hashes.Velocity, value); }

        public void Jump()
        {
            _animator.SetBool(Hashes.Jump, true);
        }

        public void ResetState()
        {
            _animator.SetBool(Hashes.EndWin, false);
            _animator.SetBool(Hashes.EndLost, false);
            _animator.SetInteger(Hashes.Velocity, 0);
            _animator.SetInteger(Hashes.Hammer, 0);
            _animator.SetBool(Hashes.Die, false);
            _animator.SetBool(Hashes.Jump, false);
        }
    }
}
