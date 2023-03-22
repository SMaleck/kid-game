using Game.Utility;
using UnityEngine;

namespace Game.Data.Sources
{
    [CreateAssetMenu(menuName = ProjectConst.MenuData + nameof(GlobalColorsDataSource), fileName = nameof(GlobalColorsDataSource))]
    public class GlobalColorsDataSource :ScriptableObjectDataSource
    {
        [field: SerializeField] public Color ButtonDefault;
        [field: SerializeField] public Color ButtonGreen;
        [field: SerializeField] public Color ButtonRed;
    }
}
