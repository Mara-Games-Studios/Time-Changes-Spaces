using TimeSpeed;
using TMPro;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Lake")]
    public class Lake : MonoBehaviour, IChangeableTile
    {
        [SerializeField] private TextMeshPro stateText;
        public PassableState PassableState { get; private set; } = PassableState.NotPassable;

        private void Start() => SetState(TimeState.Normal);
        
        public PassableState GetFutureState(TimeState state)
        {
            return state == TimeState.Slow ? PassableState.Passable : PassableState.NotPassable;
        }

        public void SetState(TimeState state)
        {
            PassableState =
                state == TimeState.Slow ? PassableState.Passable : PassableState.NotPassable;

            stateText.text = PassableState == PassableState.Passable ? "Lake is passed" : "Lake is not passed";
        }
    }
}
