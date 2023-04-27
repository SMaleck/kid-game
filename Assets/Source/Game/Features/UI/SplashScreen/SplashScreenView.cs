using Game.Services.Gooey.Views;
using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.UI.SplashScreen
{
    public class SplashScreenView : ScreenView
    {
        [field: SerializeField] public Button ContinueButton { get; private set; }
        [SerializeField] private RectTransform _tweenRoot;
        [SerializeField] private float _durationSeconds;

        private Tween _closeTween;
        private Action _onCompleted;

        protected override void ToInvisible(bool instant, Action onCompleted)
        {
            if (instant)
            {
                base.ToInvisible(true, onCompleted);
                return;
            }

            _onCompleted = onCompleted;

            _closeTween ??= CreateCloseTween();
            _closeTween.Restart();
        }

        private Tween CreateCloseTween()
        {
            return _tweenRoot.DOAnchorPosY(1080f, _durationSeconds)
                .SetEase(Ease.InBack)
                .OnComplete(OnTweenComplete)
                .SetAutoKill(false)
                .Pause();
        }

        private void OnTweenComplete()
        {
            _onCompleted?.Invoke();
        }
    }
}
