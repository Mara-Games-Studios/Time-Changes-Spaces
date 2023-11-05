using Player;
using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Idol")]
    internal class Idol : MonoBehaviour, IChangeableTile
    {
        public void ApplyStanding(Brain playerBrain) { }

        public PassableState GetPassableState(Brain playerBrain)
        {
            if (playerBrain.IsWithKey)
            {
                return PassableState.Passable;
            }
            else
            {
                return PassableState.NotPassable;
            }
        }

        public void SetState(TimeState state) { }
    }
}
