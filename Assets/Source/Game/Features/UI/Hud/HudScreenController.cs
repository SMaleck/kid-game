using EntiCS.Ticking;
using Game.Features.GameWorld.Levels;
using Game.Features.Ticking;
using Game.Services.Gooey.Controllers;
using Game.Static.Locators;

namespace Game.Features.UI.Hud
{
    public class HudScreenController : ScreenController<HudScreenView>, IUpdateable
    {
        private LevelStateFeature _levelState;

        public HudScreenController(HudScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            _levelState = FeatureLocator.Get<LevelStateFeature>();

            FeatureLocator.Get<TickerFeature>().SceneTicker.AddFixedUpdate(this);
        }

        public void Update(float elapsedSeconds)
        {
            View.RelativeProgress = _levelState.RelativeProgress;
        }
    }
}
