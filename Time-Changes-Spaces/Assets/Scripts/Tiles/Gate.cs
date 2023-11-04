using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    public class Gate : MonoBehaviour, IChangeableTile
    {
        public PassableState PassableState { get; private set; } = PassableState.Passable;

        public PassableState GetFutureState(TimeState state)
        {
            return state == TimeState.Normal ? PassableState.Passable : PassableState.NotPassable;
        }

        public void SetState(TimeState state)
        {
            PassableState = state == TimeState.Normal ? PassableState.Passable : PassableState.NotPassable;
        }
    }
}