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

        private void Start()
        {
            _player = FeatureLocator.Get<PlayerEntityFeature>().Entity;
            _playerTransform = _player.Get<TransformComponent>();

            _proxy = new UpdateableProxy(OnUpdate);

            FeatureLocator.Get<TickerFeature>().SceneTicker
                .AddLateUpdate(_proxy);
        }

        private void OnUpdate(float elapsedSeconds)
        {
            var x = _playerTransform.Position.x + _xOffset;
            var y = _followY ? _playerTransform.Position.y + _yOffset : transform.position.y;

            transform.position = new Vector3(x, y, transform.position.z);
        }

        private void OnDestroy()
        {
            FeatureLocator.Get<TickerFeature>().SceneTicker
                .RemoveLateUpdate(_proxy);
        }

        private void OnValidate()
        {
            _uCamera ??= GetComponent<UCamera>();
        }
    }
}
