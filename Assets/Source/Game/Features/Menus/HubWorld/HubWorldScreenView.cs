using Game.Services.Gooey.Views;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.Menus.HubWorld
{
    public class HubWorldScreenView : ScreenView
    {
        [field: SerializeField] public List<HubWorldLevelItem> LevelItems { get; private set; }
        [field: SerializeField] public Button ExitToTitleButton { get; private set; }
    }
}
