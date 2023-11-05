using Player;
using Tiles;
using TimeSpeed;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Key")]
    internal class Key : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private TMP_Text label;

        public void ApplyStanding(Brain playerBrain)
        {
            playerBrain.IsWithKey = true;
            label.text = "Taken";
        }

        public PassableState GetPassableState(Brain playerBrain)
        {
            return PassableState.Passable;
        }

        public void SetState(TimeState state) { }
    }
}
