using UnityEngine;

namespace Game.Utility.Mono
{
    public class DontDestroyObject : MonoBehaviour
    {
        private void Awake()
        {
            GameObject.DontDestroyOnLoad(this);
        }
    }
}
