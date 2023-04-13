using System.Collections.Generic;
using Game.Utility;
using UnityEngine;

namespace Game.Data.Sources
{
    [CreateAssetMenu(menuName = ProjectConst.MenuData + nameof(LevelElementsDataSource), fileName = nameof(LevelElementsDataSource))]
    public class LevelElementsDataSource : ScriptableObjectDataSource
    {
        [field: SerializeField] public List<GameObject> Trees { get; private set; }
        [field: SerializeField] public List<GameObject> Rocks { get; private set; }
        [field: SerializeField] public List<GameObject> Mushrooms { get; private set; }
        [field: SerializeField] public GameObject SolidGround { get; private set; }
    }
}
