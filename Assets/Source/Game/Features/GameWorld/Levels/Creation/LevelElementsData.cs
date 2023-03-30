using Game.Data;
using Game.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Features.GameWorld.Levels.Creation
{
    [CreateAssetMenu(menuName = ProjectConst.MenuData + nameof(LevelElementsData), fileName = nameof(LevelElementsData))]
    public class LevelElementsData : ScriptableObjectDataSource
    {
        [field: SerializeField] public List<GameObject> Trees { get; private set; }
        [field: SerializeField] public List<GameObject> Rocks { get; private set; }
        [field: SerializeField] public List<GameObject> Mushrooms { get; private set; }
    }
}
