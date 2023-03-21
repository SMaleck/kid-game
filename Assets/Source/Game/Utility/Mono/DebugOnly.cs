using Game.Services.ClientInfo;
using Game.Static.Locators;
using UnityEngine;

namespace Game.Utility.Mono
{
    public class DebugOnly : MonoBehaviour
    {
        [SerializeField] private bool _destroy = false;

        private void Awake()
        {
            var isDebug = ServiceLocator.Get<ClientInfoService>().IsDebug;
            if (isDebug)
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
