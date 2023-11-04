using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    [AddComponentMenu("Player.Input")]
    internal class Input : MonoBehaviour
    {
        [SerializeField]
        private Button buttonUp;

        [SerializeField]
        private Button buttonRight;

        [SerializeField]
        private Button buttonLeft;

        [SerializeField]
        private Button buttonDown;

        [SerializeField]
        private Brain brain;

        private void Awake()
        {
            buttonUp.onClick.AddListener(() => brain.TryMove(Direction.Up));
            buttonRight.onClick.AddListener(() => brain.TryMove(Direction.Right));
            buttonLeft.onClick.AddListener(() => brain.TryMove(Direction.Left));
            buttonDown.onClick.AddListener(() => brain.TryMove(Direction.Down));
        }
    }
}
