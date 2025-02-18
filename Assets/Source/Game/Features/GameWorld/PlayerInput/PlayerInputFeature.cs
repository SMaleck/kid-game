using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using Game.Features.GameWorld.Levels;
using Game.Features.GameWorld.Player;
using Game.Features.Ticking;
using Game.Features.UI.Pause;
using Game.Services.Gooey;
using Game.Static.Locators;

namespace Game.Features.GameWorld.PlayerInput
{
    public class PlayerInputFeature : Feature
    {
        private LevelStateFeature _levelStateFeature;
        private TickerFeature _tickerFeature;
        private IEntity _player;
        private JumpComponent _jumpComponent;
        private bool _isBlocked;

        private bool CanProcessInput => !_isBlocked &&
                                        _levelStateFeature.State == LevelState.Running;

        public override void OnStart()
        {
            _levelStateFeature = FeatureLocator.Get<LevelStateFeature>();
            _tickerFeature = FeatureLocator.Get<TickerFeature>();
            _player = FeatureLocator.Get<PlayerEntityFeature>().Entity;
            _jumpComponent = _player.Get<JumpComponent>();
        }

        public void Add(IPlayerInputSource source)
        {
            source.OnJump += OnJump;
            source.OnRoll += OnRoll;
            source.OnPauseGame += OnPauseGame;
        }

        public void Remove(IPlayerInputSource source)
        {
            source.OnJump -= OnJump;
            source.OnRoll -= OnRoll;
            source.OnPauseGame -= OnPauseGame;
        }

        public void SetIsBlocked(bool isBlocked)
        {
            _isBlocked = isBlocked;
        }

        private void OnJump()
        {
            if (!CanProcessInput) return;

            if (!_jumpComponent.IsJumping)
            {
                _jumpComponent.HasJumpIntent = true;
            }
        }

        private void OnRoll()
        {
            if (!CanProcessInput) return;
            // ToDo Implement roll
        }

        private void OnPauseGame()
        {
            var isPaused = !_tickerFeature.SceneTicker.IsPaused;
            _tickerFeature.SceneTicker.SetIsPaused(isPaused);

            if (isPaused)
            {
                ServiceLocator.Get<GuiServiceProxy>().TryShow<PauseModalController>();
            }
            else
            {
                ServiceLocator.Get<GuiServiceProxy>().TryHide<PauseModalController>();
            }
        }
    }
}
