using Game.Services.Gooey.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.Menus
{
    public class TitleScreenView : View
    {
        [SerializeField] private Button _startButton;

        public Button StartButton => _startButton;
    }
}
