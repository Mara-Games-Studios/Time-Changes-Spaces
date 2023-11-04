using Common;
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

        public void SetPosition(Vector2Int position)
        {
            this.position = position;
            transform.position = (Vector3)((Vector2)position * stepLength) + damp;
        }

        public void Move(Direction direction)
        {
            transform.position += (Vector3)((Vector2)direction.ToVector2Int() * stepLength);
            position += direction.ToVector2Int();
        }
    }
}
