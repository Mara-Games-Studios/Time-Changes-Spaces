using Player;
using Tiles;
using TimeSpeed;
using UnityEngine;

namespace Assets.Scripts.Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Key")]
    internal class Key : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private GameObject withStone;

        public void ApplyStanding(Brain playerBrain)
        {
            playerBrain.IsWithKey = true;
            withStone.SetActive(false);
        }

        public PassableState GetPassableState(Brain playerBrain)
        {
            return PassableState.Passable;
        }

        public void SetState(TimeState state) { }
    }
}
