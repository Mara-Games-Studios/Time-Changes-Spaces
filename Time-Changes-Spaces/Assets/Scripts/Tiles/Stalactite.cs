using System;
using TimeSpeed;
using TMPro;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Stalactite")]
    public class Stalactite : MonoBehaviour, IChangeableTile
    {
        [SerializeField] private TextMeshPro stateText;
        private bool wasActivatedSlowMode;
        public PassableState PassableState { get; private set; } = PassableState.Passable;

        private void Start() => SetState(TimeState.Normal);

        public PassableState GetFutureState(TimeState state)
        {
            if (wasActivatedSlowMode || state == TimeState.Slow)
            {
                return PassableState.NotPassable;
            }

            return PassableState.Passable;
        }

        public void SetState(TimeState state)
        {
            if (wasActivatedSlowMode || state == TimeState.Slow)
            {
                wasActivatedSlowMode = true;
                PassableState = PassableState.NotPassable;
            }
            else
            {
                PassableState = PassableState.Passable;
            }

            stateText.text = PassableState == PassableState.Passable
                ? "Stalactite can be passable"
                : "Stalactite cannot be passable";
        }
    }
}
