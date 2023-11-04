using UnityEngine;

namespace Global
{
    [AddComponentMenu("Global.GameLoader")]
    public class GameLoader : MonoBehaviour
    {
        [SerializeField]
        private SceneManager sceneManagerPrefab;

        [SerializeField]
        private AudioManager audioManagerPrefab;

        private void Awake()
        {
            if (SceneManager.Instance == null)
            {
                _ = Instantiate(sceneManagerPrefab);
            }

            if (AudioManager.Instance == null)
            {
                _ = Instantiate(audioManagerPrefab);
            }
        }
    }
}
