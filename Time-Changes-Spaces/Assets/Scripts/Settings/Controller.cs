using UnityEngine;
using UnityEngine.Audio;

namespace Settings
{
    [AddComponentMenu("Settings.Controller")]
    internal class Controller : MonoBehaviour
    {
        [SerializeField]
        private GameObject settingsPanel;

        [SerializeField]
        private AudioMixer audioMixer;

        public void Start()
        {
            Close();
        }

        public void SetSoundValue(float value)
        {
            _ = audioMixer.SetFloat("Sound", Mathf.Log10(value) * 20);
            PlayerPrefs.SetFloat("soundVolume", value);
        }

        public float GetSoundValue()
        {
            return PlayerPrefs.GetFloat("soundVolume");
        }

        public void SetMusicValue(float value)
        {
            _ = audioMixer.SetFloat("Music", Mathf.Log10(value) * 20);
            PlayerPrefs.SetFloat("musicVolume", value);
        }

        public float GetMusicValue()
        {
            return PlayerPrefs.GetFloat("musicVolume");
        }

        public void Open()
        {
            Debug.Log("Open from Settings.Controller");
            settingsPanel.SetActive(true);
            
        }

        public void Close()
        {
            settingsPanel.SetActive(false);
        }
    }
}
