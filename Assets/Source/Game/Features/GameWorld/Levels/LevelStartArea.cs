﻿using EntiCS.Entities;
using EntiCS.Ticking;
using EntiCS.Utility;
using Game.Features.EntiCS.Components;
using Game.Features.EntiCS.Components.Render;
using Game.Features.GameWorld.Player;
using Game.Features.Ticking;
using Game.Static.Locators;
using System;
using UnityEngine;

namespace Game.Features.GameWorld.Levels
{
    public class LevelStartArea : MonoBehaviour, IWorldScript
    {
        [SerializeField] private float _initialDelaySeconds;

        private ITicker _sceneTicker;
        private IEntity _player;
        private IUpdateable _updateProxy;
        private float _elapsedSeconds;

        public event Action OnComplete;

        public void RunScript()
        {
            _sceneTicker = FeatureLocator.Get<TickerFeature>().SceneTicker;
            _player = FeatureLocator.Get<PlayerEntityFeature>().Entity;
            _updateProxy = new UpdateableProxy(OnUpdate);
            _player.Get<PlayerAnimationRenderComponent>().Hammer = 0;

            _sceneTicker.Add(TickType.Update, _updateProxy);
        }

        private void OnUpdate(float elapsedSeconds)
        {
            _elapsedSeconds += elapsedSeconds;
            if (_elapsedSeconds < _initialDelaySeconds)
            {
                return;
            }

            _player.Get<MovementComponent>().MoveIntent = Vector3.right;

            _sceneTicker.Remove(TickType.Update, _updateProxy);
            OnComplete?.Invoke();
        }
    }
}
