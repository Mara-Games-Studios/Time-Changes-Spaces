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

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private string stateName;

        public void ApplyStanding(Brain playerBrain)
        {
            playerBrain.IsWithKey = true;
            withStone.SetActive(false);
        }

        public void LightUp()
        {
            if (withStone.activeSelf != false)
            {
                animator.Play(stateName);
            }
        }

        public PassableState GetPassableState(Brain playerBrain)
        {
            return PassableState.Passable;
        }

        public void SetState(TimeState state) { }
    }
}
