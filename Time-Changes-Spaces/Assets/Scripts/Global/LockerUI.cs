using UnityEngine;

namespace Global
{
    public class LockerUI : MonoBehaviour
    {
        [SerializeField]
        private Canvas lockScreenPrefab;

        public static LockerUI Instance;

        private Canvas lockScreen;

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

        private void Start()
        {
            lockScreen = Instantiate(lockScreenPrefab);
            DontDestroyOnLoad(lockScreen);
            UnLockScreen();
        }

        public void LockScreen()
        {
            lockScreen.gameObject.SetActive(true);
        }

        public void UnLockScreen()
        {
            lockScreen.gameObject.SetActive(false);
        }

        public bool IsLocked => lockScreen.gameObject.activeSelf;
    }
}
