using TimeSpeed;
using TMPro;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Lava")]
    public class Lava : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private TextMeshPro stateText;
        private bool wasActivatedSlowMode;
        public PassableState PassableState { get; private set; } = PassableState.NotPassable;

        private void Start()
        {
            SetState(TimeState.Normal);
        }

        public PassableState GetFutureState(TimeState state)
        {
            if (wasActivatedSlowMode || state == TimeState.Slow)
            {
                return PassableState.Passable;
            }

            return PassableState.NotPassable;
        }

        public void SetState(TimeState state)
        {
            if (wasActivatedSlowMode || state == TimeState.Slow)
            {
                wasActivatedSlowMode = true;
                PassableState = PassableState.Passable;
            }
            else
            {
                PassableState = PassableState.NotPassable;
            }

            stateText.text =
                PassableState == PassableState.Passable ? "Lava is obsidian" : "Lava is lava";
        }
    }
}
