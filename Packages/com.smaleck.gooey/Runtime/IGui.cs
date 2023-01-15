using System;

namespace Gooey
{
    public interface IGui
    {
        bool IsVisible { get; }

        void Show(Action onComplete = null);
        void Hide(Action onComplete = null);
        void SetIsVisible(bool isVisible);
    }
}
