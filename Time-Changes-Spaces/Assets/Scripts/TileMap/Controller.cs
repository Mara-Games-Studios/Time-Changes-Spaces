using System;
using System.Collections.Generic;
using Tiles;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TileMap
{
    [AddComponentMenu("TileMap.Controller")]
    internal class Controller : MonoBehaviour
    {
        [SerializeField]
        private Tilemap tileMap;

        [SerializeField]
        private Vector2Int leftUp;

        [SerializeField]
        private Vector2Int rightDown;
        private Dictionary<Vector2Int, IChangeableTile> tiles = new();
        public Dictionary<Vector2Int, IChangeableTile> Tiles => tiles;
        private StartPoint startPoint;
        private Vector2Int startPointPosition;
        public StartPoint StartPoint => startPoint;
        public Vector2Int StartPointPosition => startPointPosition;

        public event Action OnDictionaryFilled;

        private void Start()
        {
            for (int x = leftUp.x; x < rightDown.x; x++)
            {
                for (int y = leftUp.y; y > rightDown.y; y--)
                {
                    GameObject obj = tileMap.GetInstantiatedObject(new Vector3Int(x, y, 0));
                    if (obj != null && obj.TryGetComponent(out IChangeableTile changeableTile))
                    {
                        tiles.Add(new Vector2Int(x, y), changeableTile);
                    }
                    if (obj != null && obj.TryGetComponent(out StartPoint startPoint))
                    {
                        this.startPoint = startPoint;
                        startPointPosition = new Vector2Int(x, y);
                    }
                }
            }
            OnDictionaryFilled?.Invoke();
        }
    }
}
