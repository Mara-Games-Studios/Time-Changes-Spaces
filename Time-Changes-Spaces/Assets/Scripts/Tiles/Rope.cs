using Common;
using Player;
using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Rope")]
    internal class Rope : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private GameObject rope;

        [SerializeField]
        [InspectorReadOnly]
        private PassableState passableState = PassableState.NotPassable;

        private void Start()
        {
            SetState(TimeState.Normal);
        }

        public void SetState(TimeState state)
        {
            switch (state)
            {
                case TimeState.Normal:
                    rope.SetActive(true);
                    passableState = PassableState.Passable;
                    break;
                default:
                    rope.SetActive(false);
                    passableState = PassableState.NotPassable;
                    break;
            }
        }

        public void ApplyStanding(Brain playerBrain) { }

        public PassableState GetPassableState(Brain playerBrain)
        {
            return passableState;
        }
    }
}
