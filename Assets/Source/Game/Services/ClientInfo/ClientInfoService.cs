using UnityEngine;

namespace Game.Services.ClientInfo
{
    public class ClientInfoService : Service
    {
        public string Version => UnityEngine.Application.version;
        public RuntimePlatform Platform => UnityEngine.Application.platform;
        public bool IsDebug => UnityEngine.Debug.isDebugBuild;
    }
}
