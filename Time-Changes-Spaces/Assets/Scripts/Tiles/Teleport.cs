using System.Collections.Generic;
using System.Linq;
using Common;
using Player;
using TimeSpeed;
using UnityEngine;

namespace Tiles
{
    [AddComponentMenu("Scripts/Tiles/Tiles.Teleport")]
    internal class Teleport : MonoBehaviour, IChangeableTile
    {
        [SerializeField]
        private GameObject onTeleport;

        [SerializeField]
        private GameObject offTeleport;

        [SerializeField]
        private bool canTP = true;

        [SerializeField]
        [InspectorReadOnly]
        private PassableState passableState = PassableState.Teleportable;

        public void ApplyStanding(Brain playerBrain)
        {
            if (FindAnyObjectByType<Controller>().CurrentTimeState != TimeState.Normal)
            {
                return;
            }

            TileMap.Controller tileMapController = FindAnyObjectByType<TileMap.Controller>();
            IEnumerable<KeyValuePair<Vector2Int, IChangeableTile>> teleports = tileMapController
                .Tiles
                .Where(x => x.Value is Teleport);
            KeyValuePair<Vector2Int, IChangeableTile> other = teleports.First(
                x => (x.Value as Teleport) != this
            );
            playerBrain.Movement.SetPosition(other.Key);
        }

        public PassableState GetPassableState(Brain playerBrain)
        {
            return passableState;
        }

        public void SetState(TimeState state)
        {
            switch (state)
            {
                case TimeState.Fast:
                    onTeleport.SetActive(false);
                    canTP = false;
                    passableState = PassableState.NotTeleportable;
                    offTeleport.SetActive(true);
                    break;
                case TimeState.Normal:
                    onTeleport.SetActive(true);
                    canTP = true;
                    passableState = PassableState.Teleportable;
                    offTeleport.SetActive(false);
                    break;
                case TimeState.Slow:
                    onTeleport.SetActive(false);
                    canTP = false;
                    passableState = PassableState.NotTeleportable;
                    offTeleport.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        public bool GetCanTP()
        {
            return canTP;
        }
    }
}
