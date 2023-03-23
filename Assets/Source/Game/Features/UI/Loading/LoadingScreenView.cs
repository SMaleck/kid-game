using DG.Tweening;
using Game.Services.Gooey.Views;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.UI.Loading
{
    public sealed class LoadingScreenView : ScreenView
    {
        [SerializeField] private Image _background;
        [SerializeField] private float _fadeDurationSeconds;
        [SerializeField] private Ease _fadeEase;

        private Tween _showTween;
        private Tween ShowTween => _showTween ??= CreateShowTween();

        private Tween _hideTween;
        private Tween HideTween => _hideTween ??= CreateHideTween();

        private Action _onCompleted;

        private void OnCompleted()
        {
            _onCompleted.Invoke();
        }

        protected override void ToVisible(bool instant, Action onCompleted)
        {
            IsVisible = true;

            if (instant)
            {
                _background.color = SetAlpha(_background.color, 1f);
                onCompleted.Invoke();
                return;
            }

            _onCompleted = onCompleted;
            ShowTween.Restart();
        }

        protected override void ToInvisible(bool instant, Action onCompleted)
        {
            if (instant)
            {
                _background.color = SetAlpha(_background.color, 0f);
                IsVisible = false;
                onCompleted.Invoke();
                return;
            }

            _onCompleted = onCompleted;
            HideTween.Restart();
        }

        private Tween CreateShowTween()
        {
            return DOTween.Sequence()
                .AppendCallback(() =>
                {
                    IsVisible = true;
                    _background.color = SetAlpha(_background.color, 0f);
                })
                .Append(_background.DOFade(1f, _fadeDurationSeconds).SetEase(_fadeEase))
                .AppendCallback(OnCompleted)
                .Pause()
                .SetAutoKill(false);
        }

        private Tween CreateHideTween()
        {
            return DOTween.Sequence()
                .AppendCallback(() => _background.color = SetAlpha(_background.color, 1f))
                .Append(_background.DOFade(0f, _fadeDurationSeconds).SetEase(_fadeEase))
                .AppendCallback(() =>
                {
                    IsVisible = false;
                    OnCompleted();
                })
                .Pause()
                .SetAutoKill(false);
        }

        private Color SetAlpha(Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }
    }
}
