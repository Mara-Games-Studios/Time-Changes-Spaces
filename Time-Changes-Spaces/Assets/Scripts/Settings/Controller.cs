using UnityEngine;

namespace Settings
{
    [AddComponentMenu("Settings.Controller")]
    internal class Controller : MonoBehaviour
    {
        [SerializeField]
        private GameObject settingsPanel;

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
