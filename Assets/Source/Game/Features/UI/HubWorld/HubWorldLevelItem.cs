using Game.Features.LevelSelection;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.UI.HubWorld
{
    public class HubWorldLevelItem : MonoBehaviour
    {
        [field: SerializeField] public LevelComplexity Complexity { get; private set; }
        [field: SerializeField] public Button StartButton { get; private set; }
    }
}
