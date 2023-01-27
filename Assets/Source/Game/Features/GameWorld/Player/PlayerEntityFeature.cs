using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using UnityEngine;

namespace Game.Features.GameWorld.Player
{
    public class PlayerEntityFeature : MonoFeature
    {
        [SerializeField] private MonoEntity _entity;

        public IEntity Entity => _entity;
        public RunStatsComponent RunStats { get; private set; }

        public override void OnStart()
        {
            RunStats = Entity.Get<RunStatsComponent>();
        }
    }
}
