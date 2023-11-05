using Global;
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
            AudioManager.Instance.SetSoundPlayerPref(value);
        }

        public float GetSoundValue()
        {
            return AudioManager.Instance.GetSoundPlayerPref();
        }

        public void SetMusicValue(float value)
        {
            _ = audioMixer.SetFloat("Music", Mathf.Log10(value) * 20);
            AudioManager.Instance.SetMusicPlayerPref(value);
        }

        public float GetMusicValue()
        {
            return AudioManager.Instance.GetMusicPlayerPref();
        }

        public void Open()
        {
            settingsPanel.SetActive(true);
        }

        public void Close()
        {
            settingsPanel.SetActive(false);
        }
    }
}
