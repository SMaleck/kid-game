using Game.Services.Gooey.Views;
using Game.Utility.Mono;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.UI.Settings
{
    public class SettingsModalView : ModalView
    {
        [field: SerializeField] public Button CloseButton { get; private set; }

        [field: SerializeField] public Button ENLangButton { get; private set; }
        [field: SerializeField] public Button DELangButton { get; private set; }
        [field: SerializeField] public Button PLLangButton { get; private set; }
        [field: SerializeField] public TextClickHandler GitHubUrlText { get; private set; }
    }
}
