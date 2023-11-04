using TimeSpeed;
using TMPro;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Sarcophagus")]
    public class Sarcophagus : MonoBehaviour, IChangeableTile
    {
        [SerializeField] private TextMeshPro stateText;
        private bool wasActivatedFastMode;
        public PassableState PassableState { get; private set; } = PassableState.NotPassable;

        private void Start() => SetState(TimeState.Normal);
        
        public PassableState GetFutureState(TimeState state)
        {
            if (wasActivatedFastMode || state == TimeState.Fast)
            {
                return PassableState.Passable;
            }

            return PassableState.NotPassable;
        }

        public void SetState(TimeState state)
        {
            if (wasActivatedFastMode || state == TimeState.Fast)
            {
                wasActivatedFastMode = true;
                PassableState = PassableState.Passable;
            }
            else
            {
                PassableState = PassableState.NotPassable;
            }

            stateText.text = PassableState == PassableState.Passable
                ? "Sarcophagus is passable"
                : "Sarcophagus is not passable";
        }
    }
}
