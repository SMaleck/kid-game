using UnityEngine;

namespace Game.Services.Gooey.Views
{
    public class View : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private bool _startsVisible;

        public bool IsVisible
        {
            get => _root.activeSelf;
            set => _root.SetActive(value);
        }

        private void Awake()
        {
            IsVisible = _startsVisible;
        }
    }
}
