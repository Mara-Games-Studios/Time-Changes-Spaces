using Common;
using System;
using Tiles;
using TimeSpeed;
using UnityEngine;
using UnityEngine.Rendering.UI;

namespace Player
{
    [AddComponentMenu("Player.Brain")]
    internal class Brain : MonoBehaviour
    {
        [SerializeField]
        private TileMap.Controller tileMapController;

        [SerializeField]
        private Movement movement;

        [SerializeField] 
        private Controller timeSpeedController;
        

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
                if (changeableTile.PassableState == PassableState.Passable)
                {
                    movement.Move(direction);
                    OnTryMove?.Invoke(true);
                }
                else
                {
                    OnTryMove?.Invoke(false);
                }
            }
            else
            {
                // TODO:
                OnTryMove?.Invoke(false);
            }
        }

        public bool IsPlacedOnCorrectState(TimeState futureTimeState)
        {
            // TODO:A
            
            return false;
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
                if (changeableTile.PassableState == PassableState.NotPassable)
                {
                    OnDieOnWrongCell?.Invoke();
                    Debug.Log("Die");
                }
            }
        }
    }
}
