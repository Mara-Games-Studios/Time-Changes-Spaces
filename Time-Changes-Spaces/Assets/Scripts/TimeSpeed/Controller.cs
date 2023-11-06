using Common;
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

        [SerializeField]
        private Animator playerAnimator;

        [SerializeField]
        private List<AudioSource> timeSounds; //0 - Fast

        //1 - Normal
        //2 - Slow

        [SerializeField]
        [InspectorReadOnly]
        private TimeState currentTimeState = TimeState.Normal;
        public TimeState CurrentTimeState => currentTimeState;

        public event Action<TimeState> OnTimeStateChanged;

        public void SetTimeState(TimeState timeState)
        {
            currentTimeState = timeState;
            foreach (KeyValuePair<Vector2Int, IChangeableTile> tile in tileMapController.Tiles)
            {
                tile.Value.SetState(timeState);
            }
            PlaySoundOnTimeChange(timeState);
            OnTimeStateChanged?.Invoke(CurrentTimeState);

            switch (timeState)
            {
                case TimeState.Fast:
                    playerAnimator.speed = 3f;
                    break;
                case TimeState.Normal:
                    playerAnimator.speed = 1;
                    break;
                case TimeState.Slow:
                    playerAnimator.speed = 1f;
                    break;
                default:
                    break;
            }
        }

        private void PlaySoundOnTimeChange(TimeState timeState)
        {
            switch (timeState)
            {
                case TimeState.Slow:
                    timeSounds[0].Play();
                    break;
                case TimeState.Normal:
                    timeSounds[1].Play();
                    break;
                case TimeState.Fast:
                    timeSounds[2].Play();
                    break;
            }
        }
    }
}
