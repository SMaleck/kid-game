using Game.Services.ClientInfo;
using Game.Static.Locators;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Utility.Mono
{
    public class PlatformOnly : MonoBehaviour
    {
        [SerializeField] private List<PlatformType> _platforms;
        [SerializeField] private bool _destroy;

        private void Awake()
        {
            var platformType = ServiceLocator.Get<ClientInfoService>().PlatformType;

            var isAvailable = _platforms.Contains(platformType);
            if (isAvailable)
            {
                return;
            }

            if (_destroy)
            {
                GameObject.Destroy(this);
                return;
            }

            gameObject.SetActive(false);
        }
    }
}
