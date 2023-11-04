using Common;
using Tiles;
using TimeSpeed;
using UnityEngine;

namespace Player
{
    [AddComponentMenu("Player.Brain")]
    internal class Brain : MonoBehaviour
    {
        [SerializeField]
        private TileMap.Controller tileMapController;

        [SerializeField]
        private Movement movement;

        public void TryMove(Direction direction)
        {
            if (
                tileMapController.Tiles.TryGetValue(
                    movement.Position + direction.ToVector2Int(),
                    out IChangeableTile changeableTile
                )
            )
            {
                if (changeableTile.PassableState == PassableState.Passable)
                {
                    movement.Move(direction);
                }
            }
        }

        public bool IsPlacedOnCorrectState(TimeState futureTimeState)
        {
            // TODO:
            return false;
        }
    }
}
