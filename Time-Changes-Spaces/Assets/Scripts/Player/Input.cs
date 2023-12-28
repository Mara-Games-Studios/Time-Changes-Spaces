using Common;
using UnityEngine;

namespace Player
{
    [AddComponentMenu("Player.Input")]
    internal class Input : MonoBehaviour
    {
        [Header("KB")]
        [SerializeField]
        private KeyCode upKB;

        [SerializeField]
        private KeyCode rightKB;

        [SerializeField]
        private KeyCode leftKB;

        [SerializeField]
        private KeyCode downKB;

        //[Header("On Screen UI")]
        //[SerializeField]
        //private Button buttonUp;

        //[SerializeField]
        //private Button buttonRight;

        //[SerializeField]
        //private Button buttonLeft;

        //[SerializeField]
        //private Button buttonDown;

        [SerializeField]
        private Brain brain;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(upKB))
            {
                brain.TryMove(Direction.Up);
            }

            if (UnityEngine.Input.GetKeyDown(downKB))
            {
                brain.TryMove(Direction.Down);
            }

            if (UnityEngine.Input.GetKeyDown(leftKB))
            {
                brain.TryMove(Direction.Left);
            }

            if (UnityEngine.Input.GetKeyDown(rightKB))
            {
                brain.TryMove(Direction.Right);
            }
        }

        //private void OnEnable()
        //{
        //    buttonUp.onClick.AddListener(() => brain.TryMove(Direction.Up));
        //    buttonRight.onClick.AddListener(() => brain.TryMove(Direction.Right));
        //    buttonLeft.onClick.AddListener(() => brain.TryMove(Direction.Left));
        //    buttonDown.onClick.AddListener(() => brain.TryMove(Direction.Down));
        //}

        //private void OnDisable()
        //{
        //    buttonUp.onClick.RemoveListener(() => brain.TryMove(Direction.Up));
        //    buttonRight.onClick.RemoveListener(() => brain.TryMove(Direction.Right));
        //    buttonLeft.onClick.RemoveListener(() => brain.TryMove(Direction.Left));
        //    buttonDown.onClick.RemoveListener(() => brain.TryMove(Direction.Down));
        //}
    }
}
