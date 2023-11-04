using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    public class Hole : MonoBehaviour, IChangeableTile
    {
        private bool wasActivatedFastMode;
        public PassableState PassableState { get; private set; } = PassableState.NotPassable; 
        
        public PassableState GetFutureState(TimeState state)
        {
            if (wasActivatedFastMode || state == TimeState.Fast)
                return PassableState.NotPassable;
            
            return PassableState.Passable;
        }

        public void SetState(TimeState state)
        {
            if (wasActivatedFastMode || state == TimeState.Fast)
            {
                wasActivatedFastMode = true;
                PassableState = PassableState.NotPassable;
            }
            else
            {
                PassableState = PassableState.Passable;
            }
        }
    }
}