using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Hole")]
    public class Hole : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private GameObject openedHole;

        [SerializeField]
        private GameObject closedHole;

        private bool wasActivatedFastMode;
        public PassableState PassableState { get; private set; } = PassableState.NotPassable;

        private void Start()
        {
            SetState(TimeState.Normal);
        }

        public PassableState GetFutureState(TimeState state)
        {
            if (wasActivatedFastMode || state == TimeState.Fast)
            {
                return PassableState.NotPassable;
            }
            return PassableState.Passable;
        }

        public void SetState(TimeState state)
        {
            if (wasActivatedFastMode || state == TimeState.Fast)
            {
                wasActivatedFastMode = true;
                PassableState = PassableState.NotPassable;
                closedHole.SetActive(false);
                openedHole.SetActive(true);
            }
            else
            {
                PassableState = PassableState.Passable;
            }
        }
    }
}
