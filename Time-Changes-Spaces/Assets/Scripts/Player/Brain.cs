using Common;
using System;
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
        public Movement Movement => movement;

        [SerializeField]
        private Controller timeSpeedController;

        [SerializeField]
        private bool isWithKey;
        public bool IsWithKey
        {
            get => isWithKey;
            set => isWithKey = value;
        }

        public event Action<bool> OnTryMove;
        public event Action OnDieOnWrongCell;

        private void OnEnable()
        {
            timeSpeedController.OnTimeStateChanged += IsOnCorrectCell;
        }

        private void OnDisable()
        {
            timeSpeedController.OnTimeStateChanged -= IsOnCorrectCell;
        }

        public void TryMove(Direction direction)
        {
            if (
                tileMapController.Tiles.TryGetValue(
                    movement.Position + direction.ToVector2Int(),
                    out IChangeableTile changeableTile
                )
            )
            {
                if (changeableTile.GetPassableState(this) == PassableState.Passable)
                {
                    movement.Move(direction);
                    OnTryMove?.Invoke(true);
                    changeableTile.ApplyStanding(this);
                }
                else
                {
                    OnTryMove?.Invoke(false);
                }
            }
            else
            {
                OnTryMove?.Invoke(false);
            }
        }

        private void IsOnCorrectCell(TimeState timeState)
        {
            if (
                tileMapController.Tiles.TryGetValue(
                    movement.Position,
                    out IChangeableTile changeableTile
                )
            )
            {
                if (changeableTile.GetPassableState(this) == PassableState.NotPassable)
                {
                    OnDieOnWrongCell?.Invoke();
                }
            }
        }
    }
}
