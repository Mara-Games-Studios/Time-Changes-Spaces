using System.Linq;
using Common;
using Global;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    [AddComponentMenu("Player.Input")]
    internal class Input : MonoBehaviour
    {
        [SerializeField]
        private Brain brain;

        [SerializeField]
        private Button buttonW;

        [SerializeField]
        private Button buttonA;

        [SerializeField]
        private Button buttonS;

        [SerializeField]
        private Button buttonD;

        private void Start()
        {
            buttonW = FindObjectsByType<Button>(
                    FindObjectsInactive.Include,
                    FindObjectsSortMode.None
                )
                .First(x => x.name == "UpButton");
            buttonW.onClick.AddListener(() => brain.TryMove(Direction.Up));

            buttonA = FindObjectsByType<Button>(
                    FindObjectsInactive.Include,
                    FindObjectsSortMode.None
                )
                .First(x => x.name == "LeftButton");
            buttonA.onClick.AddListener(() => brain.TryMove(Direction.Left));

            buttonS = FindObjectsByType<Button>(
                    FindObjectsInactive.Include,
                    FindObjectsSortMode.None
                )
                .First(x => x.name == "RightButton");
            buttonS.onClick.AddListener(() => brain.TryMove(Direction.Right));

            buttonD = FindObjectsByType<Button>(
                    FindObjectsInactive.Include,
                    FindObjectsSortMode.None
                )
                .First(x => x.name == "DownButton");
            buttonD.onClick.AddListener(() => brain.TryMove(Direction.Down));
        }

        private void Update()
        {
            if (LockerUI.Instance.IsLocked)
            {
                return;
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                brain.TryMove(Direction.Up);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                brain.TryMove(Direction.Left);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.S))
            {
                brain.TryMove(Direction.Down);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.D))
            {
                brain.TryMove(Direction.Right);
            }
        }
    }
}
