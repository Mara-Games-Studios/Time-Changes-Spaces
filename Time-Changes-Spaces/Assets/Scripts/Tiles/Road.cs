using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Tiles.Road")]
    internal class Road : MonoBehaviour, IChangeableTile
    {
        public PassableState PassableState => PassableState.Passable;

        public PassableState GetFutureState(TimeState state)
        {
            return PassableState.Passable;
        }

        public void SetState(TimeState state) { }
    }
}
