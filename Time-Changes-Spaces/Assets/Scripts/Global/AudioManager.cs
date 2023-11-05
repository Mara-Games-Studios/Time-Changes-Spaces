using UnityEngine;

namespace Global
{
    [AddComponentMenu("Global.AudioManager")]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance = null;

        //public static bool Music = true;
        //public static bool Sounds = true;

        private Settings.MainInput mainInput;
        private void Start()
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
            InitializeManager();
        }

        public void SetSoundPlayerPref(float value)
        {
            PlayerPrefs.SetFloat("soundVolume", value);
        }

        public float GetSoundPlayerPref()
        {
            return PlayerPrefs.GetFloat("soundVolume");
        }

        public void SetMusicPlayerPref(float value)
        {
            PlayerPrefs.SetFloat("musicVolume", value);
        }

        public float GetMusicPlayerPref()
        {
            return PlayerPrefs.GetFloat("musicVolume");
        }

        private void InitializeManager()
        {
            //Music = System.Convert.ToBoolean(PlayerPrefs.GetString("music", "true"));
            //Sounds = System.Convert.ToBoolean(PlayerPrefs.GetString("sounds", "true"));
        }

        public static void SaveSettings()
        {
            //PlayerPrefs.SetString("music", Music.ToString());
            //PlayerPrefs.SetString("sounds", Sounds.ToString());
            PlayerPrefs.Save();
        }
    }
}
