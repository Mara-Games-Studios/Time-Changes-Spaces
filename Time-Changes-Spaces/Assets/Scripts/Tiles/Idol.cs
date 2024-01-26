using Assets.Scripts.Tiles;
using Player;
using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Idol")]
    internal class Idol : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private GameObject withStone;

        public void ApplyStanding(Brain playerBrain) { }

        public PassableState GetPassableState(Brain playerBrain)
        {
            if (playerBrain.IsWithKey)
            {
                withStone.SetActive(true);
                return PassableState.Passable;
            }
            else
            {
                FindAnyObjectByType<Key>().LightUp();
                return PassableState.NotPassable;
            }
        }

        public void SetState(TimeState state) { }
    }
}
