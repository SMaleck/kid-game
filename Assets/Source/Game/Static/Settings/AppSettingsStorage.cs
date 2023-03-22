using UnityEngine;

namespace Game.Static.Settings
{
    public class AppSettingsStorage
    {
        // ------------------------------ STRING
        public string GetString(string key)
        {
            return PlayerPrefs.GetString(key, string.Empty);
        }

        public bool TryGetString(string key, out string value)
        {
            value = GetString(key);
            return PlayerPrefs.HasKey(key);
        }

        public void Set(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }

        // ------------------------------ BOOL
        public bool GetBool(string key)
        {
            return PlayerPrefs.GetInt(key, 0) == 1;
        }

        public bool TryGetBool(string key, out bool value)
        {
            value = GetBool(key);
            return PlayerPrefs.HasKey(key);
        }

        public void Set(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }

        // ------------------------------ INT
        public int GetInt(string key)
        {
            return PlayerPrefs.GetInt(key, 0);
        }

        public bool TryGetInt(string key, out int value)
        {
            value = GetInt(key);
            return PlayerPrefs.HasKey(key);
        }

        public void Set(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        // ------------------------------ FLOAT
        public float GetFloat(string key)
        {
            return PlayerPrefs.GetFloat(key, 0f);
        }

        public bool TryGetFloat(string key, out float value)
        {
            value = GetFloat(key);
            return PlayerPrefs.HasKey(key);
        }

        public void Set(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }
    }
}
