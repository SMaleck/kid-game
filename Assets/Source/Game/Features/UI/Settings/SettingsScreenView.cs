using Game.Services.Gooey.Views;
using Game.Utility.Mono;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.UI.Settings
{
    public class SettingsScreenView : ScreenView
    {
        [field: SerializeField] public Button CloseButton { get; private set; }

        [field: SerializeField] public Button ENLangButton { get; private set; }
        [field: SerializeField] public Button DELangButton { get; private set; }
        [field: SerializeField] public Button PLLangButton { get; private set; }
        [field: SerializeField] public TextClickHandler GitHubUrlText { get; private set; }
        [field: SerializeField] public TMP_Text ClientInfoText { get; private set; }
    }
}
