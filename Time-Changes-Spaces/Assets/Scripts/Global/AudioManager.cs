using UnityEngine;

namespace Global
{
    [AddComponentMenu("Global.AudioManager")]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public void SetSoundPlayerPref(float value)
        {
            PlayerPrefs.SetFloat("soundVolume", value);
            SaveSettings();
        }

        public float GetSoundPlayerPref()
        {
            return PlayerPrefs.GetFloat("soundVolume");
        }

        public void SetMusicPlayerPref(float value)
        {
            PlayerPrefs.SetFloat("musicVolume", value);
            SaveSettings();
        }

        public float GetMusicPlayerPref()
        {
            return PlayerPrefs.GetFloat("musicVolume");
        }

        public static void SaveSettings()
        {
            PlayerPrefs.Save();
        }
    }
}
