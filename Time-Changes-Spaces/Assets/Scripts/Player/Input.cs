using Common;
using Global;
using UnityEngine;

namespace Player
{
    [AddComponentMenu("Player.Input")]
    internal class Input : MonoBehaviour
    {
        [SerializeField]
        private Brain brain;

        private void Update()
        {
            if (LockerUI.Instance.IsLocked)
            {
                return;
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                brain.TryMove(Direction.Up);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                brain.TryMove(Direction.Left);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.S))
            {
                brain.TryMove(Direction.Down);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.D))
            {
                brain.TryMove(Direction.Right);
            }
        }
    }
}
