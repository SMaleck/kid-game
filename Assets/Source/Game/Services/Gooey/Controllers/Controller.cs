using Game.Services.Gooey.Views;
using Gooey;
using System;
using Game.Utility;

namespace Game.Services.Gooey.Controllers
{
    public class Controller<TView> : IGui where TView : View
    {
        private bool _wasShownOnce;
        protected readonly TView View;

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
            
            OnBeforeShow();

            onComplete ??= ObjectConst.DefaultAction;
            View.SetIsVisible(true, instant, onComplete);

            OnAfterShow();
        }
        
        public void Hide(Action onComplete = null)
        {
            Hide(false, onComplete);
        }

        public void Hide(bool instant, Action onComplete = null)
        {
            OnBeforeHide();

            onComplete ??= ObjectConst.DefaultAction;
            View.SetIsVisible(false, instant, onComplete);

            OnAfterHide();
        }
        
        protected virtual void Initialize() { }
        protected virtual void OnBeforeShow() { }
        protected virtual void OnBeforeHide() { }

        protected virtual void OnAfterShow() { }
        protected virtual void OnAfterHide() { }
    }
}
