using DG.Tweening;
using EntiCS.Entities;
using EntiCS.Ticking;
using EntiCS.Utility;
using Game.Features.EntiCS.Components;
using Game.Features.GameWorld.Player;
using Game.Features.Ticking;
using Game.Static.Locators;
using UnityEngine;

namespace Game.Features.GameWorld.Camera
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private UCamera _uCamera;

        [Header("Follow Settings")]
        [SerializeField] public float _xOffset;
        [SerializeField] public bool _followY;
        [SerializeField] public float _yOffset;

        private IUpdateable _proxy;
        private IEntity _player;
        private TransformComponent _playerTransform;

        public bool IsFollowing { get; set; } = true;

        public void TweenTo(Vector3 position, Vector3 rotation, float durationSeconds)
        {
            IsFollowing = false;

            DOTween.Sequence()
                .Append(transform
                    .DOMove(position, durationSeconds)
                    .SetEase(Ease.InOutQuad))
                .Join(transform
                    .DORotate(rotation, durationSeconds)
                    .SetEase(Ease.InOutQuad));
        }

        private void Start()
        {
            _player = FeatureLocator.Get<PlayerEntityFeature>().Entity;
            _playerTransform = _player.Get<TransformComponent>();

            _proxy = new UpdateableProxy(OnUpdate);

            FeatureLocator.Get<TickerFeature>().SceneTicker
                .Add(TickType.LateUpdate, _proxy);
        }

        private void OnUpdate(float elapsedSeconds)
        {
            if (!IsFollowing) return;

            var x = _playerTransform.Position.x + _xOffset;
            var y = _followY ? _playerTransform.Position.y + _yOffset : transform.position.y;

            transform.position = new Vector3(x, y, transform.position.z);
        }

        private void OnDestroy()
        {
            FeatureLocator.Get<TickerFeature>().SceneTicker
                .Remove(TickType.LateUpdate, _proxy);
        }

        private void OnValidate()
        {
            _uCamera ??= GetComponent<UCamera>();
        }
    }
}
