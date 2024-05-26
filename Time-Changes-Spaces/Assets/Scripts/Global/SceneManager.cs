using Common;
using UnityEngine;

namespace Global
{
    [AddComponentMenu("Global.SceneManager")]
    internal class SceneManager : MonoBehaviour
    {
        [Scene]
        [SerializeField]
        private string level1String;

        [Scene]
        [SerializeField]
        private string mainMenu;

        [SerializeField]
        private AudioSource levelFinishSound;

        public static SceneManager Instance = null;

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

        public void LoadMainMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenu);
        }

        public void LoadScene(string gameScene, bool playSound = true)
        {
            if (!gameScene.Equals(level1String) && playSound)
            {
                levelFinishSound.Play();
            }

            UnityEngine.SceneManagement.SceneManager.LoadScene(gameScene);
        }

        public void ReloadScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
            );
        }
    }
}
