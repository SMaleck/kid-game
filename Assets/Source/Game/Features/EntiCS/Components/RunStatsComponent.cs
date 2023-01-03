using EntiCS.Entities.Components;
using Game.Features.EntiCS.Utility;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class RunStatsComponent : MonoEntityComponent, IResettable
    {
        public bool StartedRecording { get; set; }
        public Vector3 Origin { get; set; }
        public float ElapsedDistanceUnits { get; set; }
        public float ElapsedSeconds { get; set; }

        public void ResetState()
        {
            StartedRecording = false;
            Origin = default;
            ElapsedDistanceUnits = 0;
            ElapsedDistanceUnits = 0;
        }
    }
}
