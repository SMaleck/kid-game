using Game.Static.Locators;
using UnityEngine;

namespace Game.Features.GameWorld.Camera
{
    public class UCamera : MonoBehaviour
    {
        [field: SerializeField] public UnityEngine.Camera Camera { get; private set; }

        public bool IsActive
        {
            get => Camera.isActiveAndEnabled;
            set => gameObject.SetActive(value);
        }

        public void Start()
        {
            FeatureLocator.Get<CameraFeature>().Push(this);
        }

        public void OnDestroy()
        {
            FeatureLocator.Get<CameraFeature>().Remove(this);
        }

        private void OnValidate()
        {
            Camera ??= GetComponent<UnityEngine.Camera>();
        }
    }
}
