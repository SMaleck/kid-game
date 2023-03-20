using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using Game.Features.GameWorld.Player;
using Game.Features.Ticking;
using Game.Static.Locators;

namespace Game.Features.GameWorld.PlayerInput
{
    public class PlayerInputFeature : Feature
    {
        private TickerFeature _tickerFeature;
        private IEntity _player;
        private JumpComponent _jumpComponent;

        public override void OnStart()
        {
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

        private void OnJump()
        {
            if (!_jumpComponent.IsJumping)
            {
                _jumpComponent.HasJumpIntent = true;
            }
        }

        private void OnRoll()
        {

        }

        private void OnPauseGame()
        {
            _tickerFeature.SceneTicker.SetIsPaused(!_tickerFeature.SceneTicker.IsPaused);
        }
    }
}
