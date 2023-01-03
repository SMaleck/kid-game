using System;
using System.Collections.Generic;
using System.Linq;
using Game.Data;
using Game.Services.Gooey.Views;
using Game.Utility;
using UnityEngine;

namespace Game.Services.Gooey.Data
{
    [CreateAssetMenu(menuName = ProjectConst.MenuData + nameof(GuiPrefabDataSource), fileName = nameof(GuiPrefabDataSource))]
    public class GuiPrefabDataSource : ScriptableObjectDataSource
    {
        [SerializeField] private List<View> _viewPrefabs;

        private IReadOnlyDictionary<string, View> _viewPrefabsByName;

        public View GetPrefab(Type viewType)
        {
            return GetCache()[AsKey(viewType)];
        }

        private IReadOnlyDictionary<string, View> GetCache()
        {
            return _viewPrefabsByName ??= _viewPrefabs
                .ToDictionary(e =>
                {
                    var type = e.GetType();
                    return AsKey(type);
                });
        }

        private string AsKey(Type type)
        {
            return $"{type.Namespace}.{type.Name}";
        }
    }
}
