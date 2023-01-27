using Game.Static.Locators;
using UnityEngine;

namespace Game.Features
{
    public class MonoFeature : MonoBehaviour, IFeature
    {
        public virtual void OnStart() { }
        public virtual void OnEnd() { }
    }
}
