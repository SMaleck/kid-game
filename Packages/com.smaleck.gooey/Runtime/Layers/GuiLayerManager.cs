using Gooey.Utility;
using System;
using System.Collections.Generic;

namespace Gooey.Layers
{
    public class GuiLayerManager : IGuiLayerManager
    {
        private readonly int _maxVisibleLayers;

        private readonly IDictionary<Type, IGui> _guis = new Dictionary<Type, IGui>();
        private readonly List<IGui> _visibleGuis = new List<IGui>();
        private readonly Action _defaultAction = () => { };

        public GuiLayerManager(int maxVisibleLayers)
        {
            _maxVisibleLayers = maxVisibleLayers;
        }

        public void Add(IGui gui)
        {
            var type = gui.GetType();
            if (_guis.ContainsKey(type))
            {
                GooeyLog.Warn($"Tried to add already registered GUI Type: {type}. Ignoring");
                return;
            }

            _guis.Add(type, gui);
        }

        public void Remove(IGui gui)
        {
            var type = gui.GetType();
            if (!_guis.ContainsKey(type))
            {
                GooeyLog.Warn($"Tried to remove not registered GUI Type: {type}. Ignoring");
                return;
            }

            _guis.Remove(type);
        }

        public IGui Get<TGui>() where TGui : IGui
        {
            return Get(typeof(TGui));
        }

        public IGui Get(Type type)
        {
            if (_guis.TryGetValue(type, out var gui))
            {
                return gui;
            }

            return null;
        }

        public bool TryShow<TGui>(Action onComplete = null) where TGui : IGui
        {
            return TryShow(typeof(TGui), onComplete);
        }

        public bool TryShow(Type type, Action onComplete = null)
        {
            if (_guis.TryGetValue(type, out var gui) &&
                !gui.IsVisible)
            {
                SanitizeOpenGuiCountForOpening();

                gui.Show(onComplete ?? _defaultAction);
                _visibleGuis.Add(gui);

                return true;
            }

            return false;
        }

        public bool TryHide<TGui>(Action onComplete = null) where TGui : IGui
        {
            return TryHide(typeof(TGui), onComplete);
        }

        public bool TryHide(Type type, Action onComplete = null)
        {
            if (_guis.TryGetValue(type, out var gui) &&
                gui.IsVisible)
            {
                gui.Hide(onComplete ?? _defaultAction);
                _visibleGuis.Remove(gui);

                return true;
            }

            return false;
        }

        private void SanitizeOpenGuiCountForOpening()
        {
            while (_visibleGuis.Count >= _maxVisibleLayers)
            {
                var type = _visibleGuis[^1].GetType();
                TryHide(type);
            }
        }
    }
}
