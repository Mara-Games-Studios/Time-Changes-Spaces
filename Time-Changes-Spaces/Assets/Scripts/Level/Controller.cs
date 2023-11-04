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

        private void Awake()
        {
            tileMapController.OnDictionaryFilled += () =>
                movement.SetPosition(tileMapController.StartPointPosition);
        }
    }
}
