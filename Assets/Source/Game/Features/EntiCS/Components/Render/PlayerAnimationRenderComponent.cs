using EntiCS.Entities.Components;
using Game.Features.EntiCS.Utility;
using Game.Utility.Extensions;
using UnityEngine;

namespace Game.Features.EntiCS.Components.Render
{
    public class PlayerAnimationRenderComponent : EntityComponent, IResettable
    {
        private static class Hashes
        {
            public static int EndWin = Animator.StringToHash("EndWin"); // BOOL
            public static int EndLost = Animator.StringToHash("EndLost"); // BOOL
            public static int Velocity = Animator.StringToHash("Velocity"); // INT
            public static int Hammer = Animator.StringToHash("Hammer"); // INT
            public static int Die = Animator.StringToHash("Die"); // BOOL
            public static int Jump = Animator.StringToHash("Jump"); // BOOL
        }

        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _hammerParent;

        public int Velocity { set => _animator.SetInteger(Hashes.Velocity, value.Clamp(0, 2)); }
        public int Hammer { set => SetHammer(value); }
        public bool Jump { set => _animator.SetBool(Hashes.Jump, value); }

        public void Win()
        {
            _animator.SetBool(Hashes.EndWin, true);
        }

        public void Lose()
        {
            _animator.SetBool(Hashes.EndLost, true);
        }
        
        public void Die()
        {
            _animator.SetBool(Hashes.Die, true);
        }

        public void ResetState()
        {
            Velocity = 0;
            Hammer = 0;
            Jump = false;

            _animator.SetBool(Hashes.EndWin, false);
            _animator.SetBool(Hashes.EndLost, false);
            _animator.SetBool(Hashes.Die, false);
        }

        private void SetHammer(int value)
        {
            _hammerParent.SetActive(value > 0);
            _animator.SetInteger(Hashes.Hammer, value.Clamp(0, 2));
        }
    }
}
