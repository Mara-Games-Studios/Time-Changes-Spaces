using Common;
using Player;
using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Hole")]
    internal class Hole : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private GameObject openedHole;

        [SerializeField]
        private GameObject closedHole;

        [SerializeField]
        [InspectorReadOnly]
        private PassableState passableState = PassableState.Passable;

        private bool wasActivatedFastMode;

        private void Start()
        {
            SetState(TimeState.Normal);
        }

        public void SetState(TimeState state)
        {
            if (wasActivatedFastMode || state == TimeState.Fast)
            {
                wasActivatedFastMode = true;
                passableState = PassableState.NotPassable;
                closedHole.SetActive(false);
                openedHole.SetActive(true);
            }
            else
            {
                passableState = PassableState.Passable;
            }
        }

        public void ApplyStanding(Brain playerBrain) { }

        public PassableState GetPassableState(Brain playerBrain)
        {
            return passableState;
        }
    }
}
