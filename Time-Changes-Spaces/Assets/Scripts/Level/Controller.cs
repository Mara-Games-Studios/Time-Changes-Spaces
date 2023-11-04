using Common;
using Player;
using UnityEngine;

namespace Level
{
    [AddComponentMenu("Level.Controller")]
    internal class Controller : MonoBehaviour
    {
        [SerializeField]
        private Movement movement;

        [SerializeField]
        private TileMap.Controller tileMapController;

        [SerializeField]
        private Brain brain;

        [SerializeField]
        private TimeSpeed.Controller timeSpeedController;

        [SerializeField]
        private uint stepsToLose;

        [Scene]
        [SerializeField]
        private string nextScene;

        private void OnEnable()
        {
            tileMapController.OnDictionaryFilled += TileMapController_OnDictionaryFilled;
            brain.OnTryMove += Brain_OnTryMove;
            timeSpeedController.OnTimeStateChanged += TickTime;
        }

        private void TileMapController_OnDictionaryFilled()
        {
            movement.SetPosition(tileMapController.StartPointPosition);
        }

        private void Brain_OnTryMove(bool isAllowed)
        {
            if (isAllowed)
            {
                TickTime();
            }
        }

        private void TickTime()
        {
            // TODO: implement
        }

        private void OnDisable()
        {
            tileMapController.OnDictionaryFilled -= TileMapController_OnDictionaryFilled;
            brain.OnTryMove -= Brain_OnTryMove;
            timeSpeedController.OnTimeStateChanged -= TickTime;
        }
    }
}
