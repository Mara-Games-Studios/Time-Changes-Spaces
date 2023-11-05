using Common;
using Player;
using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Lake")]
    internal class Lake : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private GameObject waterFast;

        [SerializeField]
        private GameObject waterStandard;

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
                case TimeState.Fast:
                    waterFast.SetActive(false);
                    waterStandard.SetActive(true);
                    passableState = PassableState.Passable;
                    break;
                default:
                    waterFast.SetActive(true);
                    waterStandard.SetActive(false);
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
