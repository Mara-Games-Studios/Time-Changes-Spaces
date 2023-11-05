using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    [AddComponentMenu("Scripts/Settings/Settings.MainInput")]
    internal class MainInput : MonoBehaviour
    {
        [SerializeField]
        private Controller controller;

        [SerializeField]
        private Button buttonClose;

        [SerializeField]
        private Slider soundSlider;

        [SerializeField]
        private Slider musicSlider;

        private void Start()
        {
            SetSlidersFromPrefs();
        }

        private void OnEnable()
        {
            buttonClose.onClick.AddListener(ButtonClose_OnClick);
            soundSlider.onValueChanged.AddListener(SetSoundVolume);
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }
        private void SetSoundVolume(float value)
        {
            controller.SetSoundValue(value);
        }

        private void SetMusicVolume(float value)
        {
            controller.SetMusicValue(value);
        }

        private void SetSlidersFromPrefs()
        {
            if (PlayerPrefs.HasKey("musicVolume"))
            {
                soundSlider.value = controller.GetSoundValue();
                musicSlider.value = controller.GetMusicValue();
            }
            SetSoundVolume(soundSlider.value);
            SetMusicVolume(musicSlider.value);
        }
        private void ButtonClose_OnClick()
        {
            controller.Close();
        }

        private void OnDisable()
        {
            buttonClose.onClick.RemoveListener(ButtonClose_OnClick);
            soundSlider.onValueChanged.RemoveListener(SetSoundVolume);
            musicSlider.onValueChanged.RemoveListener(SetMusicVolume);
        }
    }
}
