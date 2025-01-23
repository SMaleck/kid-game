using EntiCS.Entities.Components;
using Game.Features.EntiCS.Components.Generic;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class LifecycleComponent : EntityComponent, ILifecycleComponent
    {
        [field: SerializeField] public bool IsAlive { get; set; } = true;

        [SerializeField] private int _health = 1;
        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                IsAlive = _health > 0;
            }
        }
    }
}
