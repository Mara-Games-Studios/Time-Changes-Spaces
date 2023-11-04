using System;
using TimeSpeed;
using TMPro;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Hole")]
    public class Hole : MonoBehaviour, IChangeableTile
    {
        [SerializeField] private TextMeshPro stateText;
        private bool wasActivatedFastMode;
        public PassableState PassableState { get; private set; } = PassableState.NotPassable;

        private void Start() => SetState(TimeState.Normal);

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
            }
            else
            {
                PassableState = PassableState.Passable;
            }

            stateText.text = PassableState == PassableState.Passable ? "Hole can be passed" : "Hole cannot be passed";
        }
    }
}
