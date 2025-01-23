using EntiCS.Entities.Components;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public enum DamageType 
    {
        Amount = 0,
        InstaKill = 1
    }

    public class DamageComponent : EntityComponent
    {
        [field: SerializeField] public DamageType Type { get; set; }
        [field: SerializeField] public int Amount { get; set; } = 1;
    }
}
