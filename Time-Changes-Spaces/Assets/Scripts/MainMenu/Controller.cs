using Common;
using Global;
using UnityEngine;

namespace MainMenu
{
    [AddComponentMenu("MainMenu.Controller")]
    internal class Controller : MonoBehaviour
    {
        [Scene]
        [SerializeField]
        private string firstLevel;

        [SerializeField]
        private Settings.Controller settingsController;

        public void Play()
        {
            SceneManager.Instance.LoadScene(firstLevel);
        }

        public void Settings()
        {
            settingsController.Open();
        }
    }
}
