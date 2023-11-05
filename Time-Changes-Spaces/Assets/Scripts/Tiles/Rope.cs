using Common;
using Player;
using TimeSpeed;
using TMPro;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Rope")]
    internal class Rope : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private TMP_Text label;

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
                    label.text = "Rope is passable";
                    passableState = PassableState.Passable;
                    break;
                default:
                    label.text = "Rope is not passable";
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
