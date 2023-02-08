using System;

namespace Gooey
{
    public interface IGui
    {
        bool IsVisible { get; }

        void Show(Action onComplete = null);
        void Show(bool instant = false, Action onComplete = null);

        void Hide(Action onComplete = null);
        void Hide(bool instant = false, Action onComplete = null);
    }
}
