﻿using EntiCS.Entities;
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

        private void OnJump()
        {
            if (_levelStateFeature.State != LevelState.Running) return;

            if (!_jumpComponent.IsJumping)
            {
                _jumpComponent.HasJumpIntent = true;
            }
        }

        private void OnRoll()
        {
            if (_levelStateFeature.State != LevelState.Running) return;
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
