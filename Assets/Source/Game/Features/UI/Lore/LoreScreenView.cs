using Game.Services.Gooey.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.UI.Lore
{
    public class LoreScreenView : ScreenView
    {
        [field: SerializeField] public Button BackButton { get; private set; }
    }
}
