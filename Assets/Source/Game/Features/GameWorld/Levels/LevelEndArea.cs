﻿using EntiCS.Entities;
using EntiCS.Ticking;
using EntiCS.Utility;
using Game.Features.GameWorld.Player;
using Game.Features.Ticking;
using Game.Static.Locators;
using System;
using UnityEngine;

namespace Game.Features.GameWorld.Levels
{
    public class LevelEndArea : MonoBehaviour, IWorldScript
    {
        [SerializeField] private ParticleSystem _buildingDustPS;
        [SerializeField] private GameObject _houseBroken;
        [SerializeField] private GameObject _houseFixed;

        private ITicker _sceneTicker;
        private IEntity _player;
        private IUpdateable _updateProxy;
        public event Action OnComplete;

        private float _elapsedSeconds;
        private float _replaceHouseAtSeconds => _buildingDustPS.main.duration / 2f;

        private void Start()
        {
            _sceneTicker = FeatureLocator.Get<TickerFeature>().SceneTicker;
            _player = FeatureLocator.Get<PlayerEntityFeature>().Entity;
            _updateProxy = new UpdateableProxy(OnUpdate);

            _houseBroken.SetActive(true);
            _houseFixed.SetActive(false);
        }

        public void RunScript()
        {
            _buildingDustPS.Play();

            _sceneTicker.AddUpdate(_updateProxy);
        }

        private void OnUpdate(float elapsedSeconds)
        {
            _elapsedSeconds += elapsedSeconds;
            if (_elapsedSeconds >= _replaceHouseAtSeconds &&
                !_houseFixed.activeSelf)
            {
                _houseBroken.SetActive(false);
                _houseFixed.SetActive(true);
            }

            if (IsComplete())
            {
                _sceneTicker.RemoveUpdate(_updateProxy);
                OnComplete?.Invoke();
            }
        }

        private bool IsComplete()
        {
            return !_buildingDustPS.isPaused &&
                   !_buildingDustPS.isPlaying;
        }
    }
}