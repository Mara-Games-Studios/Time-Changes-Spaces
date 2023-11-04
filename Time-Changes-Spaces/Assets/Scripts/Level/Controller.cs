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

        private void Awake()
        {
            tileMapController.OnDictionaryFilled += () =>
                movement.SetPosition(tileMapController.StartPointPosition);
            brain.OnTryMove += TickTime;
            timeSpeedController.OnTimeStateChanged += TickTime;
        }

        private void TickTime()
        {
            // TODO: implement
        }
    }
}
