using Game.Services.Gooey.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.UI.Welcome
{
    public class WelcomeScreenView : ScreenView
    {
        [field: SerializeField] public GameObject BackButtonParent { get; private set; }
        [field: SerializeField] public Button BackButton { get; private set; }
        [field: SerializeField] public Button StartButton { get; private set; }
        [field: SerializeField] public TMP_InputField UserNameInput { get; private set; }
        [field: SerializeField] public InputField UserNameInputLegacy { get; private set; }
    }
}
