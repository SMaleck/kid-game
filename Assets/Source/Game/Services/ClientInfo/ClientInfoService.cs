using System;
using UnityEngine;

namespace Game.Services.ClientInfo
{
    public class ClientInfoService : Service
    {
        public string Version => UnityEngine.Application.version;
        public RuntimePlatform Platform => UnityEngine.Application.platform;
        public PlatformType PlatformType { get; }
        public bool IsDebug => UnityEngine.Debug.isDebugBuild;

        public string InfoString { get; }

        public ClientInfoService()
        {
            PlatformType = GetPlatformType();
            InfoString = GetInfoString();
        }

        private string GetInfoString()
        {
            var envLabel = IsDebug ? "Debug" : "Release";
            return $"v{Version} | {envLabel} | Platform: {Platform} - Type: {PlatformType}";
        }

        private PlatformType GetPlatformType()
        {
            switch(Platform)
            {
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.LinuxEditor:
                    return PlatformType.Editor;

                case RuntimePlatform.OSXPlayer:
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.LinuxPlayer:
                    return PlatformType.Computer;
                    
                case RuntimePlatform.WebGLPlayer:
                    return PlatformType.Browser;
                
                case RuntimePlatform.IPhonePlayer:
                case RuntimePlatform.Android:
                    return PlatformType.Mobile;

                case RuntimePlatform.PS4:
                case RuntimePlatform.XboxOne:
                case RuntimePlatform.Switch:
                case RuntimePlatform.GameCoreXboxSeries:
                case RuntimePlatform.GameCoreXboxOne:
                case RuntimePlatform.PS5:
                    return PlatformType.Console;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
