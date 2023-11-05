using TimeSpeed;
using TMPro;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Trap")]
    public class Trap : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private TextMeshPro stateText;
        public PassableState PassableState { get; private set; } = PassableState.NotPassable;

        private void Start()
        {
            SetState(TimeState.Normal);
        }

        public PassableState GetFutureState(TimeState state)
        {
            return state == TimeState.Fast ? PassableState.Passable : PassableState.NotPassable;
        }

        public void SetState(TimeState state)
        {
            PassableState =
                state == TimeState.Fast ? PassableState.Passable : PassableState.NotPassable;

            stateText.text =
                PassableState == PassableState.Passable ? "Trap is passed" : "Trap is not passed";
        }
    }
}
