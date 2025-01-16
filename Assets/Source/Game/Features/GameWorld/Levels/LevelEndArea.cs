using EntiCS.Entities;
using EntiCS.Ticking;
using EntiCS.Utility;
using Game.Features.EntiCS.Components;
using Game.Features.EntiCS.Components.Render;
using Game.Features.GameWorld.Camera;
using Game.Features.GameWorld.Player;
using Game.Features.Ticking;
using Game.Services.Audio;
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
        [SerializeField] private AudioClip _jingleAudioClip;

        [Header("Camera")]
        [SerializeField] private PlayerCamera _camera;

        [Tooltip("X is handled as an offset from the player position")]
        [SerializeField] private Vector3 _targetPos;
        [SerializeField] private Vector3 _targetRot;

        private ITicker _sceneTicker;
        private IEntity _player;
        private IUpdateable _updateProxy;
        public event Action OnComplete;

        private float _elapsedSeconds;
        private float _replaceHouseAtSeconds => _buildingDustPS.main.duration / 2f;

        private void Start()
        {
            if(_camera == null)
            {
                _camera = UnityEngine.Camera.main.GetComponent<PlayerCamera>();
            }

            _sceneTicker = FeatureLocator.Get<TickerFeature>().SceneTicker;
            _player = FeatureLocator.Get<PlayerEntityFeature>().Entity;
            _updateProxy = new UpdateableProxy(OnUpdate);

            _houseBroken.SetActive(true);
            _houseFixed.SetActive(false);
        }

        public void RunScript()
        {
            var targetPos = new Vector3(
                _player.Get<TransformComponent>().Position.x + _targetPos.x,
                _targetPos.y,
                _targetPos.z);

            _player.Get<PlayerAnimationRenderComponent>().Hammer = 1;
            _camera.TweenTo(targetPos, _targetRot, _replaceHouseAtSeconds);
            _buildingDustPS.Play();

            _sceneTicker.Add(TickType.Update, _updateProxy);
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
                _player.Get<PlayerAnimationRenderComponent>().Hammer = 0;
                _player.Get<PlayerAnimationRenderComponent>().Win();

                _sceneTicker.Remove(TickType.Update, _updateProxy);
                OnComplete?.Invoke();

                ServiceLocator.Get<AudioService>().PlayMusic(_jingleAudioClip, false);
            }
        }

        private bool IsComplete()
        {
            return !_buildingDustPS.isPaused &&
                   !_buildingDustPS.isPlaying;
        }
    }
}
