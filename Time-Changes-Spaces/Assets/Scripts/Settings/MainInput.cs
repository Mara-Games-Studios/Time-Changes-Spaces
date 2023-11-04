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

        private void OnEnable()
        {
            buttonClose.onClick.AddListener(ButtonClose_OnClick);
        }

        private void ButtonClose_OnClick()
        {
            controller.Close();
        }

        private void OnDisable()
        {
            buttonClose.onClick.RemoveListener(ButtonClose_OnClick);
        }
    }
}
