using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Stalactite")]
    public class Stalactite : MonoBehaviour, IChangeableTile
    {
        private bool wasActivatedSlowMode;
        public PassableState PassableState { get; private set; } = PassableState.Passable;
        
        public PassableState GetFutureState(TimeState state)
        {
            if (wasActivatedSlowMode || state == TimeState.Slow)
                return PassableState.NotPassable;

            return PassableState.Passable;
        }

        public void SetState(TimeState state)
        {
            if (wasActivatedSlowMode || state == TimeState.Slow)
            {
                wasActivatedSlowMode = true;
                PassableState = PassableState.NotPassable;
            }
            else
            {
                PassableState = PassableState.Passable;
            }
        }
    }
}