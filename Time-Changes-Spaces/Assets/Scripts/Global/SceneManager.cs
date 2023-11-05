using UnityEngine;

namespace Global
{
    [AddComponentMenu("Global.SceneManager")]
    internal class SceneManager : MonoBehaviour
    {
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
