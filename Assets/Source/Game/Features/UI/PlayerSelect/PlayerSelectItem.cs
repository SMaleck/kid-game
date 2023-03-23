using Game.Features.Savegames.SavegameObjects;
using Game.Services.Text;
using System;
using TMPro;
using UnityEngine;

namespace Game.Features.UI.PlayerSelect
{
    public sealed class PlayerSelectItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _createdAtText;
        [SerializeField] private TMP_Text _playtimeText;

        public void SetPlayer(PlayerMetadataSavegame savegame)
        {
            _nameText.text = savegame.PlayerName;
            _createdAtText.text = TextService.TimeFormatter.Timestamp(savegame.CreatedAtUtc);

            var playtime = TimeSpan.FromTicks(savegame.TotalPlayTimeTicks);
            _playtimeText.text = TextService.TimeFormatter.Duration(playtime);
        }
    }
}
