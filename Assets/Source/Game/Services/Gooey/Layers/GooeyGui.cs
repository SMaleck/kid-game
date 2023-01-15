﻿using System;
using Gooey;

namespace Game.Services.Gooey.Layers
{
    public class GooeyGui : IGui
    {
        public bool IsVisible { get; protected set; }

        public void Show(Action onComplete = null)
        {
            onComplete?.Invoke();
        }

        public void Hide(Action onComplete = null)
        {
            onComplete?.Invoke();
        }

        public void SetIsVisible(bool isVisible)
        {
            IsVisible = isVisible;
        }
    }
}
