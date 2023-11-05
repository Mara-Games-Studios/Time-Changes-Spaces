using TimeSpeed;
using TMPro;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.AlwaysNotPassable")]
    public class AlwaysNotPassable : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private TextMeshPro stateText;
        public PassableState PassableState => PassableState.NotPassable;

        public PassableState GetFutureState(TimeState state)
        {
            return PassableState.NotPassable;
        }

        public void SetState(TimeState state) { }
    }
}
