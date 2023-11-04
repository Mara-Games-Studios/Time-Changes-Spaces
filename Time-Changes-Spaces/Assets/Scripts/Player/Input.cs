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
        private Brain movement;

        private void Awake()
        {
            buttonUp.onClick.AddListener(() => movement.TryMove(Direction.Up));
            buttonRight.onClick.AddListener(() => movement.TryMove(Direction.Right));
            buttonLeft.onClick.AddListener(() => movement.TryMove(Direction.Left));
            buttonDown.onClick.AddListener(() => movement.TryMove(Direction.Down));
        }
    }
}
