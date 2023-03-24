using Game.Features.Player;
using Game.Features.Savegames.SavegameObjects;
using Game.Services.Scenes;
using Game.Services.Text;
using Game.Static.Locators;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.UI.PlayerSelect
{
    public sealed class PlayerSelectItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _createdAtText;
        [SerializeField] private TMP_Text _playtimeText;
        [SerializeField] private Button _selectButton;

        private PlayerMetadataSavegame _savegame;

        public void SetPlayer(PlayerMetadataSavegame savegame)
        {
            _savegame = savegame;

            _nameText.text = savegame.PlayerName;
            _createdAtText.text = TextService.Get(TextKeys.CreatedAtStamp, TextService.TimeFormatter.Timestamp(savegame.CreatedAtUtc));

            var playtime = TimeSpan.FromTicks(savegame.TotalPlayTimeTicks);
            _playtimeText.text = TextService.Get(TextKeys.PlaytimeStamp, TextService.TimeFormatter.Duration(playtime));

            _selectButton.onClick.AddListener(OnPlayerSelectClicked);
        }

        private void OnPlayerSelectClicked()
        {
            if (FeatureLocator.Get<PlayerStateFeature>().SwitchTo(_savegame.Id))
            {
                ServiceLocator.Get<SceneService>().ReloadGame();
            }
            
        }
    }
}
