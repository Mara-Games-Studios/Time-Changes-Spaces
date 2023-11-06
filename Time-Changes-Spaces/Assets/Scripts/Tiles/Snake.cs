using Common;
using Player;
using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Snake")]
    internal class Snake : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private Animator animator;

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
                case TimeState.Slow:
                    animator.speed = 3;
                    passableState = PassableState.Passable;
                    break;
                case TimeState.Normal:
                    animator.speed = 1;
                    passableState = PassableState.NotPassable;
                    break;
                default:
                    animator.speed = 0.1f;
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
