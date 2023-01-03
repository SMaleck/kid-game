using System;

namespace Gooey
{
    public interface IGui
    {
        bool IsVisible { get; }

        void Show(Action onComplete);
        void Hide(Action onComplete);
        void SetIsVisible(bool isVisible);
    }
}
