using Common;
using Player;
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

        [SerializeField]
        private Brain playerBrain;

        [SerializeField]
        [InspectorReadOnly]
        private TimeState currentTimeState = TimeState.Normal;

        public void SetTimeState(TimeState timeState)
        {
            if (playerBrain.IsPlacedOnCorrectState(timeState))
            {
                // TODO: Lose game
            }

            foreach (KeyValuePair<Vector2Int, IChangeableTile> tile in tileMapController.Tiles)
            {
                tile.Value.SetState(timeState);
            }
        }
    }
}
