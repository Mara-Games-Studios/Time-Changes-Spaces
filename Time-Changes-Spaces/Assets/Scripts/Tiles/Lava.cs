using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    public class Lava : MonoBehaviour, IChangeableTile
    {
        private bool wasActivatedSlowMode;
        public PassableState PassableState { get; private set; } = PassableState.NotPassable;
        
        public PassableState GetFutureState(TimeState state)
        {
            if (wasActivatedSlowMode || state == TimeState.Slow)
                return PassableState.Passable;
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
        }
    }
}