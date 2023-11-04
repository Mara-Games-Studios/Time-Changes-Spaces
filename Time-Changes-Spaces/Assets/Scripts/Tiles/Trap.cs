using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    public class Trap : MonoBehaviour, IChangeableTile
    {
        public PassableState PassableState { get; private set; } = PassableState.NotPassable;
        
        public PassableState GetFutureState(TimeState state)
        {
            return state == TimeState.Fast ? PassableState.Passable : PassableState.NotPassable;
        }

        public void SetState(TimeState state)
        {
            PassableState = state == TimeState.Fast ? PassableState.Passable : PassableState.NotPassable;
        }
    }
}