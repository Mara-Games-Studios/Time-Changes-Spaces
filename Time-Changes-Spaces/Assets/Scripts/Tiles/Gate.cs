using System;
using TimeSpeed;
using TMPro;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Gate")]
    public class Gate : MonoBehaviour, IChangeableTile
    {
        [SerializeField] private TextMeshPro stateText;
        public PassableState PassableState { get; private set; } = PassableState.Passable;

        private void Start() => SetState(TimeState.Normal);

        public PassableState GetFutureState(TimeState state)
        {
            return state == TimeState.Normal ? PassableState.Passable : PassableState.NotPassable;
        }

        public void SetState(TimeState state)
        {
            PassableState =
                state == TimeState.Normal ? PassableState.Passable : PassableState.NotPassable;

            stateText.text = PassableState == PassableState.Passable ? "Gate is open" : "Gate is closed";
        }
    }
}
