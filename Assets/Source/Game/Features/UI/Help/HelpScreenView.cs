using Game.Services.Gooey.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.UI.Help
{
    public class HelpScreenView : ScreenView
    {
        [field: SerializeField] public Button BackButton { get; private set; }
    }
}
