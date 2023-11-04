using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    [AddComponentMenu("MainMenu.Input")]
    internal class Input : MonoBehaviour
    {
        [SerializeField]
        private Controller controller;

        [SerializeField]
        private Button buttonPlay;

        [SerializeField]
        private Button buttonSettings;

        private void OnEnable()
        {
            buttonPlay.onClick.AddListener(ButtonPlay_OnClick);
            buttonSettings.onClick.AddListener(ButtonSettings_OnClick);
        }

        private void ButtonPlay_OnClick()
        {
            controller.Play();
        }

        private void ButtonSettings_OnClick()
        {
            controller.Settings();
        }

        private void OnDisable()
        {
            buttonPlay.onClick.RemoveListener(ButtonPlay_OnClick);
            buttonSettings.onClick.RemoveListener(ButtonSettings_OnClick);
        }
    }
}
