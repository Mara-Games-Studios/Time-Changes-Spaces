using UnityEngine;

namespace Global
{
    public class LockerUI : MonoBehaviour
    {
        [SerializeField]
        private Canvas lockCanvas;

        public static LockerUI Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public void LockScreen()
        {
            lockCanvas.gameObject.SetActive(true);
        }

        public void UnLockScreen()
        {
            lockCanvas.gameObject.SetActive(false);
        }
    }
}
