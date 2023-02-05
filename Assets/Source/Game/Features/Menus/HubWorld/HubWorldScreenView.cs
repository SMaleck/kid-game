using Game.Services.Gooey.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.Menus.HubWorld
{
    public class HubWorldScreenView : ScreenView
    {
        [field: SerializeField] public Button StartButton { get; private set; }
        [field: SerializeField] public Button ExitToTitleButton { get; private set; }
    }
}
