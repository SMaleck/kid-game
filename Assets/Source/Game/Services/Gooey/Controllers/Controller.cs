using System;
using Game.Services.Gooey.Views;
using Gooey;

namespace Game.Services.Gooey.Controllers
{
    public class Controller<TView> : IGui where TView : View
    {
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

        public void Show(Action onComplete)
        {
            IsVisible = true;
            onComplete.Invoke();
        }

        public void Hide(Action onComplete)
        {
            IsVisible = false;
            onComplete.Invoke();
        }

        public void SetIsVisible(bool isVisible)
        {
            IsVisible = isVisible;
        }
    }
}
