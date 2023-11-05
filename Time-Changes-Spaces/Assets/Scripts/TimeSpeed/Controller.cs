using Common;
using Player;
using System;
using System.Collections.Generic;
using Tiles;
using UnityEngine;

namespace TimeSpeed
{
    public enum TimeState
    {
        Fast,
        Normal,
        Slow
    }

    [AddComponentMenu("TimeSpeed.Controller")]
    internal class Controller : MonoBehaviour
    {
        [SerializeField]
        private TileMap.Controller tileMapController;

<<<<<<< Updated upstream
        [SerializeField]
        private Brain playerBrain;

=======
>>>>>>> Stashed changes
        [SerializeField]
        [InspectorReadOnly]
        private TimeState currentTimeState = TimeState.Normal;
        public TimeState CurrentTimeState => currentTimeState;

        public event Action<TimeState> OnTimeStateChanged;

        private void Start() => SetTimeState(TimeState.Normal);
        
        public void SetTimeState(TimeState timeState)
        {
            currentTimeState = timeState;
<<<<<<< Updated upstream
            if (playerBrain.IsPlacedOnCorrectState(timeState))
=======
            foreach (KeyValuePair<Vector2Int, IChangeableTile> tile in tileMapController.Tiles)
>>>>>>> Stashed changes
            {
                // TODO: Lose game
            }
            else
            {
                foreach (KeyValuePair<Vector2Int, IChangeableTile> tile in tileMapController.Tiles)
                {
                    tile.Value.SetState(timeState);
                }

                OnTimeStateChanged?.Invoke(CurrentTimeState);
            }
        }
    }
}
