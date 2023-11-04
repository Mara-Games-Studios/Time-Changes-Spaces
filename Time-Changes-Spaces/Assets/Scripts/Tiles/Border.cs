using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Border")]
    public class Border : MonoBehaviour, IChangeableTile
    {
        public PassableState PassableState => PassableState.NotPassable;
        
        public PassableState GetFutureState(TimeState state)
        {
            return PassableState.NotPassable;
        }

        public void SetState(TimeState state)
        {
        }
    }
}