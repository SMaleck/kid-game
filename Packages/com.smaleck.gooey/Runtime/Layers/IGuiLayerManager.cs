using System;

namespace Gooey.Layers
{
    public interface IGuiLayerManager
    {
        void Add(IGui gui);
        void Remove(IGui gui);

        IGui Get<TGui>() where TGui : IGui;
        IGui Get(Type type);

        bool TryShow<TGui>(Action onComplete = null) where TGui : IGui;
        bool TryShow(Type type, Action onComplete = null);

        bool TryHide<TGui>(Action onComplete = null) where TGui : IGui;
        bool TryHide(Type type, Action onComplete = null);
    }
}