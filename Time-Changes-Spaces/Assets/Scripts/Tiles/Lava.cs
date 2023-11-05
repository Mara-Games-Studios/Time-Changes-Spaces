using Common;
using Player;
using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Lava")]
    internal class Lava : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private GameObject defaultLava;

        [SerializeField]
        private GameObject obsidian;

        private bool wasActivatedSlowMode;

        [SerializeField]
        [InspectorReadOnly]
        private PassableState passableState = PassableState.NotPassable;

        private void Start()
        {
            SetState(TimeState.Normal);
        }

        public void SetState(TimeState state)
        {
            if (wasActivatedSlowMode || state == TimeState.Slow)
            {
                wasActivatedSlowMode = true;
                passableState = PassableState.Passable;
                obsidian.SetActive(true);
                defaultLava.SetActive(false);
            }
            else
            {
                passableState = PassableState.NotPassable;
            }
        }

        public void ApplyStanding(Brain playerBrain) { }

        public PassableState GetPassableState(Brain playerBrain)
        {
            return passableState;
        }
    }
}
