using Player;
using TimeSpeed;
using TMPro;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.AlwaysNotPassable")]
    internal class AlwaysNotPassable : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private TextMeshPro stateText;

        public void SetState(TimeState state) { }

        public void ApplyStanding(Brain brain) { }

        public PassableState GetPassableState(Brain playerBrain)
        {
            return PassableState.NotPassable;
        }
    }
}
