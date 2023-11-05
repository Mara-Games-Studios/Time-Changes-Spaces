using Player;
using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Teleport")]
    internal class Teleport : MonoBehaviour, IChangeableTile
    {
        public void ApplyStanding(Brain playerBrain) { }

        public PassableState GetPassableState(Brain playerBrain)
        {
            return PassableState.Passable;
        }

        public void SetState(TimeState state) { }
    }
}
