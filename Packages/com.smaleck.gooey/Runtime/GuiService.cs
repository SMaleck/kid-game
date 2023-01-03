using Gooey.Layers;
using System;
using System.Collections.Generic;

namespace Gooey
{
    public class GuiService : IGuiService
    {
        private readonly Type _screenType = typeof(IScreen);
        private readonly Type _windowType = typeof(IWindow);
        private readonly Type _modalType = typeof(IModal);

        private readonly Dictionary<Type, IGuiLayerManager> _guiLayers;

        public GuiService()
        {
            _guiLayers = new Dictionary<Type, IGuiLayerManager>()
            {
                { typeof(IScreen), new GuiLayerManager(int.MaxValue) },
                { typeof(IWindow), new GuiLayerManager(int.MaxValue) },
                { typeof(IModal), new GuiLayerManager(1) },
            };
        }

        public void Add(IGui gui)
        {
            var key = GetKey(gui);
            _guiLayers[key].Add(gui);
        }

        public void Remove(IGui gui)
        {
            var key = GetKey(gui);
            _guiLayers[key].Remove(gui);
        }

        public bool TryShow<TGui>(Action onComplete = null) where TGui : IGui
        {
            var key = GetKey<TGui>();
            return GetLayer<TGui>().TryShow<TGui>(onComplete);
        }

        public bool TryShow(Type type, Action onComplete = null)
        {
            return GetLayer(type).TryShow(type, onComplete);
        }

        public bool TryHide<TGui>(Action onComplete = null) where TGui : IGui
        {
            return GetLayer<TGui>().TryHide<TGui>(onComplete);
        }

        public bool TryHide(Type type, Action onComplete = null)
        {
            return GetLayer(type).TryHide(type, onComplete);
        }

        public bool IsVisible<TGui>() where TGui : IGui
        {
            return GetLayer<TGui>().Get<TGui>().IsVisible;
        }

        public bool IsVisible(Type type)
        {
            return GetLayer(type).Get(type).IsVisible;
        }

        private IGuiLayerManager GetLayer<TGui>() where TGui : IGui
        {
            var key = GetKey<TGui>();
            return _guiLayers[key];
        }

        private IGuiLayerManager GetLayer(Type type)
        {
            var key = GetKey(type);
            return _guiLayers[key];
        }

        private Type GetKey(IGui gui)
        {
            switch (gui)
            {
                case IScreen screen:
                    return _screenType;

                case IWindow window:
                    return _windowType;

                case IModal modal:
                    return _modalType;

                default:
                    throw new InvalidOperationException($"Gui Type [{gui.GetType()}] is not supported");
            }
        }

        private Type GetKey<TGui>() where TGui : IGui
        {
            return GetKey(typeof(TGui));
        }

        private Type GetKey(Type type)
        {
            if (type.IsAssignableFrom(typeof(IScreen)))
            {
                return _screenType;
            }
            if (type.IsAssignableFrom(typeof(IWindow)))
            {
                return _windowType;
            }
            if (type.IsAssignableFrom(typeof(IModal)))
            {
                return _modalType;
            }

            throw new InvalidOperationException($"Gui Type [{type}] is not supported");
        }
    }
}
