﻿using EntiCS.Entities;
using EntiCS.Ticking;
using EntiCS.Utility;
using Game.Features.GameWorld.Player;
using Game.Features.Ticking;
using Game.Static.Locators;
using System;
using Game.Features.EntiCS.Components;
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

        private void Start()
        {
            _sceneTicker = FeatureLocator.Get<TickerFeature>().SceneTicker;
            _player = FeatureLocator.Get<PlayerEntityFeature>().Entity;
            _updateProxy = new UpdateableProxy(OnUpdate);
        }

        public void RunScript()
        {
            _sceneTicker.AddUpdate(_updateProxy);
            OnComplete?.Invoke();
        }

        private void OnUpdate(float elapsedSeconds)
        {
            _elapsedSeconds += elapsedSeconds;
            if (_elapsedSeconds < _initialDelaySeconds)
            {
                return;
            }

            if (IsComplete())
            {
                _player.Get<MovementComponent>().MoveIntent = Vector3.right;

                _sceneTicker.RemoveUpdate(_updateProxy);
                OnComplete?.Invoke();
            }
        }

        private bool IsComplete()
        {
            return true;
        }
    }
}
