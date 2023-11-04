using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Finish")]
    public class Finish : MonoBehaviour, IChangeableTile
    {
        public PassableState PassableState => PassableState.Passable;
        
        public PassableState GetFutureState(TimeState state)
        {
            return PassableState.Passable;
        }

        public void SetState(TimeState state)
        {
        }
    }
}