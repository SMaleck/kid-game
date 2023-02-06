﻿using Game.Services.Gooey.Views;
using Gooey;
using System;

namespace Game.Services.Gooey.Controllers
{
    public class Controller<TView> : IGui where TView : View
    {
        private bool _wasShownOnce;
        protected readonly TView View;

        private readonly Action _emptyAction = () => { };

        public bool IsVisible => View.IsVisible;

        public Controller(TView view)
        {
            View = view;
        }

        public void Show(Action onComplete = null)
        {
            Show(false, onComplete);
        }

        public void Show(bool instant = false, Action onComplete = null)
        {
            if (!_wasShownOnce)
            {
                Initialize();
                _wasShownOnce = true;
            }

            OnShow();
            
            onComplete ??= _emptyAction;
            View.SetIsVisible(true, instant, onComplete);
        }
        
        public void Hide(Action onComplete = null)
        {
            Hide(false, onComplete);
        }

        public void Hide(bool instant, Action onComplete = null)
        {
            OnHide();

            onComplete ??= _emptyAction;
            View.SetIsVisible(false, instant, onComplete);
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
