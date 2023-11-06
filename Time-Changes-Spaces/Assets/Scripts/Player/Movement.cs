using Common;
using Global;
using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    [AddComponentMenu("Player.Movement")]
    internal class Movement : MonoBehaviour
    {
        [SerializeField]
        [InspectorReadOnly]
        private Vector2Int position;
        public Vector2Int Position => position;

        [SerializeField]
        private Vector3 damp;

        [SerializeField]
        private float stepLength;

        [SerializeField]
        private float oneStepTime;

        [SerializeField]
        private Animator animator;

        private const string idleAnimation = "Idle";
        private const string upAnimation = "Up";
        private const string rightAnimation = "Right";
        private const string downAnimation = "Down";
        private const string leftAnimation = "Left";

        public void SetPosition(Vector2Int position)
        {
            this.position = position;
            transform.position = GetPosition(position);
        }

        public void Move(Direction direction, Action nextAction)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            LockerUI.Instance.LockScreen();
            _ = StartCoroutine(
                LerpWalk(
                    position,
                    position + direction.ToVector2Int(),
                    direction == Direction.Left,
                    nextAction
                )
            );
            switch (direction)
            {
                case Direction.Left:
                    animator.Play(leftAnimation);
                    break;
                case Direction.Right:

                    animator.Play(rightAnimation);
                    break;
                case Direction.Up:
                    animator.Play(upAnimation);
                    break;
                case Direction.Down:
                    animator.Play(downAnimation);
                    break;
            }
            LockerUI.Instance.LockScreen();
        }

        private Vector3 GetPosition(Vector2Int position)
        {
            return (Vector3)((Vector2)position * stepLength) + damp;
        }

        private IEnumerator LerpWalk(
            Vector2Int from,
            Vector2Int destination,
            bool rotateAfter,
            Action nextAction
        )
        {
            float timer = 0;
            while (timer < oneStepTime)
            {
                timer += Time.deltaTime;
                transform.position = Vector3.Lerp(
                    GetPosition(from),
                    GetPosition(destination),
                    timer / oneStepTime
                );
                yield return null;
            }
            SetPosition(destination);
            animator.Play(idleAnimation);
            if (rotateAfter)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            LockerUI.Instance.UnLockScreen();
            nextAction?.Invoke();
        }
    }
}
