using Common;
using Player;
using TimeSpeed;
using TMPro;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Snake")]
    internal class Snake : MonoBehaviour, IChangeableTile
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
                case TimeState.Slow:
                    label.text = "Passable Snake";
                    passableState = PassableState.Passable;
                    break;
                default:
                    label.text = "NOT Passable Snake";
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
