using Game.Services.Gooey.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.UI.Pause
{
    public class PauseModalView : ModalView
    {
        [field: SerializeField] public Button ResumeButton { get; private set; }
        [field: SerializeField] public Button RestartButton { get; private set; }
        [field: SerializeField] public Button QuitButton { get; private set; }
    }
}
