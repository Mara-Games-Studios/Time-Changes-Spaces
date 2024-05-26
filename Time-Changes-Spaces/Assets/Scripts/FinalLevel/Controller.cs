using Common;
using Global;
using UnityEngine;

namespace FinalLevel
{
    [AddComponentMenu("FinalLevel.Controller")]
    internal class Controller : MonoBehaviour
    {
        [Scene]
        [SerializeField]
        private string mainMenuScene;

        [SerializeField]
        private GameObject finalLevelPanel;

        [SerializeField]
        private AudioSource finalMusic;

        public void Start()
        {
            Close();
        }

        public void LoadMenu()
        {
            SceneManager.Instance.LoadScene(mainMenuScene, false);
        }

        public void Open()
        {
            finalLevelPanel.SetActive(true);
            finalMusic.Play();
        }

        public void Close()
        {
            finalLevelPanel.SetActive(false);
        }
    }
}
