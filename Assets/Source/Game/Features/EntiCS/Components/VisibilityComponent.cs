using EntiCS.Entities.Components;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class VisibilityComponent : EntityComponent
    {
        [field: SerializeField] public GameObject Root { get; set; }

        public bool IsVisible
        {
            get => Root.activeSelf;
            set => Root.SetActive(value);
        }
    }
}
