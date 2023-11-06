using UnityEngine;
using UnityEngine.UI;

namespace Level
{
    [AddComponentMenu("Level.Input")]
    internal class Input : MonoBehaviour
    {
        [SerializeField]
        private Controller controller;

        [SerializeField]
        private Button settingsButton;

        [SerializeField]
        private Button educationalButton;

        [SerializeField]
        private AudioSource tapSound;

        private void OnEnable()
        {
            settingsButton.onClick.AddListener(SettingsButton_OnClick);
            educationalButton.onClick.AddListener(EducationalButton_OnClick);
        }

        private void SettingsButton_OnClick()
        {
            controller.OpenSettings();
            tapSound.Play();
        }

        private void EducationalButton_OnClick()
        {
            tapSound.Play();
            controller.OpenEducationalPanel();
        }

        private void OnDisable()
        {
            settingsButton.onClick.RemoveListener(SettingsButton_OnClick);
            educationalButton.onClick.RemoveListener(EducationalButton_OnClick);
        }
    }
}
