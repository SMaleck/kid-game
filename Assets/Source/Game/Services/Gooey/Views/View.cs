using UnityEngine;

namespace Game.Services.Gooey.Views
{
    public class View : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [field: SerializeField] public bool StartsVisible { get; private set; }

        public bool IsVisible
        {
            get => _root.activeSelf;
            set => _root.SetActive(value);
        }
    }
}
