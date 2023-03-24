using Game.Features.Savegames.SavegameObjects;
using Game.Services.Gooey.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.UI.PlayerSelect
{
    public sealed class PlayerSelectScreenView : ScreenView
    {
        [SerializeField] private PlayerSelectItem _playerItemPrefab;
        [SerializeField] private Transform _listParent;
        [field: SerializeField] public Button BackButton { get; private set; }
        [field: SerializeField] public Button CreateButton { get; private set; }

        public void Add(PlayerMetadataSavegame savegame)
        {
            var item = GameObject.Instantiate<PlayerSelectItem>(_playerItemPrefab, _listParent);
            item.SetPlayer(savegame);
        }
    }
}
