using Game.Services.Gooey.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.Menus
{
    public class TitleScreenView : ScreenView
    {
        [field: SerializeField] public Button StartButton { get; private set; }
        [field: SerializeField] public Button SelectPlayerButton { get; private set; }
        [field: SerializeField] public Button QuitButton { get; private set; }

        [SerializeField] private TMP_Text _playerName;

        public string PlayerName
        {
            set => _playerName.text = value;
        }
    }
}
