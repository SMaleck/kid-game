using Game.Services.Gooey.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.GameWorld.Hud
{
    public class HudScreenView : ScreenView
    {
        [SerializeField] private Slider _progressSlider;

        public float RelativeProgress
        {
            set => _progressSlider.value = value;
        }
    }
}
