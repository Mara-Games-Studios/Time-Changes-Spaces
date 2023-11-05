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

        public void LoadScene(string gameScene)
        {
            if (!gameScene.Equals(level1String))
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
