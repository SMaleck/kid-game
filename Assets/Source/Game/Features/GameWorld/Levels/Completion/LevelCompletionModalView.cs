using Game.Services.Gooey.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.GameWorld.Levels.Completion
{
    public class LevelCompletionModalView : ModalView
    {
        [field: SerializeField] public Button BackButton { get; private set; }
        [field: SerializeField] public Button ReplayButton { get; private set; }
    }
}
