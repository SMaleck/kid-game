using System.Collections.Generic;
using Game.Data;
using Game.Static.Locators;
using Game.Utility;
using UnityEngine;

namespace Game.Initialization.ScriptableObjects
{
    [CreateAssetMenu(menuName = ProjectConst.MenuData + nameof(DataInitializer), fileName = nameof(DataInitializer))]
    public class DataInitializer : ScriptableObject
    {
        [SerializeField] private List<ScriptableObjectDataSource> _dataSources;

        public void Initialize()
        {
            foreach (var data in _dataSources)
            {
                DataLocator.Register(data);
            }
        }
    }
}
