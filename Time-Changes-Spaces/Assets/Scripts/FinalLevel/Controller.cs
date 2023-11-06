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

        public void Start()
        {
            Close();
        }

        public void LoadMenu()
        {
            SceneManager.Instance.LoadScene(mainMenuScene);
        }

        public void Open()
        {
            finalLevelPanel.SetActive(true);
        }

        public void Close()
        {
            finalLevelPanel.SetActive(false);
        }
    }
}
