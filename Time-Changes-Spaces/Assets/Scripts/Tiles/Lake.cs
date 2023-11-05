using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Lake")]
    public class Lake : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private GameObject waterFast;

        [SerializeField]
        private GameObject waterStandard;

        public PassableState PassableState { get; private set; } = PassableState.NotPassable;

        private void Start()
        {
            SetState(TimeState.Normal);
        }

        public PassableState GetFutureState(TimeState state)
        {
            return state == TimeState.Slow ? PassableState.Passable : PassableState.NotPassable;
        }

        public void SetState(TimeState state)
        {
            switch (state)
            {
                case TimeState.Fast:
                    waterFast.SetActive(false);
                    waterStandard.SetActive(true);
                    PassableState = PassableState.Passable;
                    break;
                default:
                    waterFast.SetActive(true);
                    waterStandard.SetActive(false);
                    PassableState = PassableState.NotPassable;
                    break;
            }
        }
    }
}
