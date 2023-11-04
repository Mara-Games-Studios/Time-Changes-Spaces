using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Lake")]
    public class Lake : MonoBehaviour, IChangeableTile
    {
        public PassableState PassableState { get; private set; } = PassableState.NotPassable;

        public PassableState GetFutureState(TimeState state)
        {
            return state == TimeState.Slow ? PassableState.Passable : PassableState.NotPassable;
        }

        public void SetState(TimeState state)
        {
            PassableState =
                state == TimeState.Slow ? PassableState.Passable : PassableState.NotPassable;
        }
    }
}
