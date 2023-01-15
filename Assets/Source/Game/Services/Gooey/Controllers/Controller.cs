using Game.Services.Gooey.Views;
using Gooey;
using System;

namespace Game.Services.Gooey.Controllers
{
    public class Controller<TView> : IGui where TView : View
    {
        private bool _wasShownOnce;
        protected readonly TView View;

        public bool IsVisible
        {
            get => View.IsVisible;
            protected set => View.IsVisible = value;
        }

        public Controller(TView view)
        {
            View = view;
        }

        public void Show(Action onComplete = null)
        {
            if (!_wasShownOnce)
            {
                Initialize();
                _wasShownOnce = true;
            }

            IsVisible = true;
            OnShow();
            onComplete?.Invoke();
        }

        public void Hide(Action onComplete = null)
        {
            IsVisible = false;
            OnHide();
            onComplete?.Invoke();
        }

        public void SetIsVisible(bool isVisible)
        {
            if (!_wasShownOnce && isVisible)
            {
                Initialize();
                _wasShownOnce = true;
            }

            IsVisible = isVisible;
        }

        protected virtual void Initialize() { }
        protected virtual void OnShow() { }
        protected virtual void OnHide() { }
    }
}
