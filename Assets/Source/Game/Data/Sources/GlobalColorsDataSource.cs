using Game.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data.Sources
{
    [CreateAssetMenu(menuName = ProjectConst.MenuData + nameof(GlobalColorsDataSource), fileName = nameof(GlobalColorsDataSource))]
    public class GlobalColorsDataSource : ScriptableObjectDataSource
    {
        [Serializable]
        public class ButtonColor
        {
            [field: SerializeField] public Color GradTop;
            [field: SerializeField] public Color GradBottom;
            [field: SerializeField] public Color Bevel;
            [field: SerializeField] public Color Shadow;
        }

        [field: SerializeField] public List<ButtonColor> ButtonColors;

        [Header("GUI Screens")]
        [field: SerializeField] public Color ScreenBackground;

        [Header("GUI Modals")]
        [field: SerializeField] public Color ModalFrame;
        [field: SerializeField] public Color ModalBackground;
    }
}
