using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Tiles.StartPoint")]
    internal class StartPoint : MonoBehaviour, IChangeableTile
    {
        public PassableState PassableState => PassableState.Passable;

        public PassableState GetFutureState(TimeState state)
        {
            return PassableState.Passable;
        }

        public void SetState(TimeState state) { }
    }
}
