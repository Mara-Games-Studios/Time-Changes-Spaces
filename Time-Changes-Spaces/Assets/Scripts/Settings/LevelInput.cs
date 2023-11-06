using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    [AddComponentMenu("Scripts/Settings/Settings.LevelInput")]
    internal class LevelInput : MonoBehaviour
    {
        [SerializeField]
        private Controller controller;

        [SerializeField]
        private Button buttonRestart;

        private void OnEnable()
        {
            buttonRestart.onClick.AddListener(ButtonRestart_OnClick);
        }

        private void ButtonRestart_OnClick()
        {
            controller.Restart();
        }

        private void OnDisable()
        {
            buttonRestart.onClick.RemoveListener(ButtonRestart_OnClick);
        }
    }
}
