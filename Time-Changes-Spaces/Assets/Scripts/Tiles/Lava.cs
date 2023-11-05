using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Lava")]
    public class Lava : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private GameObject defaultLava;

        [SerializeField]
        private GameObject obsidian;

        private bool wasActivatedSlowMode;
        public PassableState PassableState { get; private set; } = PassableState.NotPassable;

        private void Start()
        {
            SetState(TimeState.Normal);
        }

        public PassableState GetFutureState(TimeState state)
        {
            if (wasActivatedSlowMode || state == TimeState.Slow)
            {
                return PassableState.Passable;
            }
            return PassableState.NotPassable;
        }

        public void SetState(TimeState state)
        {
            if (wasActivatedSlowMode || state == TimeState.Slow)
            {
                wasActivatedSlowMode = true;
                PassableState = PassableState.Passable;
                obsidian.SetActive(true);
                defaultLava.SetActive(false);
            }
            else
            {
                PassableState = PassableState.NotPassable;
            }
        }
    }
}
