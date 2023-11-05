using Global;
using UnityEngine;

namespace MainMenu
{
    [AddComponentMenu("MainMenu.Controller")]
    internal class Controller : MonoBehaviour
    {
        [SerializeField]
        private Settings.Controller settingsController;

        public void Play()
        {
            SceneManager.Instance.LoadScene(InGameScene.FirstLevel);
        }

        public void Settings()
        {
            settingsController.Open();
            
        }
    }
}
