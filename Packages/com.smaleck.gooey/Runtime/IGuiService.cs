using System;

namespace Gooey
{
    public interface IGuiService
    {
        void Add(IGui gui);
        void Remove(IGui gui);
        bool TryShow<TGui>(Action onComplete = null) where TGui : IGui;
        bool TryShow(Type type, Action onComplete = null);
        bool TryHide<TGui>(Action onComplete = null) where TGui : IGui;
        bool TryHide(Type type, Action onComplete = null);
    }
}