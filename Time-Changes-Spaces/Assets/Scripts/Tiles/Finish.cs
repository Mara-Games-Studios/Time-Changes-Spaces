using Player;
using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Finish")]
    internal class Finish : MonoBehaviour, IChangeableTile
    {
        public void ApplyStanding(Brain playerBrain) { }

        public PassableState GetFutureState(TimeState state)
        {
            return PassableState.Passable;
        }

        public PassableState GetPassableState(Brain playerBrain)
        {
            return PassableState.Passable;
        }

        public void SetState(TimeState state) { }
    }
}
