using DG.Tweening;
using UnityEngine;

namespace Game.Utility.UI
{
    public class PulseScaleTween : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _maxScale;
        [SerializeField] private float _durationSeconds;

        private void Start()
        {
            var maxScale = new Vector3(_maxScale, _maxScale, _maxScale);

            _target
                .DOScale(maxScale, _durationSeconds)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutQuad)
                .SetAutoKill(false)
                .SetLink(gameObject);
        }
    }
}
