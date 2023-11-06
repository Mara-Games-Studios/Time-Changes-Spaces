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
        private GameObject waterObj;

        [SerializeField]
        private Animator waterStormAnimator;

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
                    waterObj.SetActive(false);
                    passableState = PassableState.Passable;
                    break;
                case TimeState.Slow:
                    waterObj.SetActive(true);
                    waterStormAnimator.speed = 3;
                    passableState = PassableState.NotPassable;
                    break;
                case TimeState.Normal:
                    waterObj.SetActive(true);
                    waterStormAnimator.speed = 1.0f;
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
