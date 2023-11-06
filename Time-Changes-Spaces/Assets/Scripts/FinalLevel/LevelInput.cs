using UnityEngine;
using UnityEngine.UI;

namespace FinalLevel
{
    [AddComponentMenu("FinalLevel.Input")]
    internal class Input : MonoBehaviour
    {
        [SerializeField]
        private Controller controller;

        [SerializeField]
        private Button buttonMainMenu;

        private void OnEnable()
        {
            buttonMainMenu.onClick.AddListener(ButtonMainMenu_OnClick);
        }

        private void ButtonMainMenu_OnClick()
        {
            controller.LoadMenu();
        }

        private void OnDisable()
        {
            buttonMainMenu.onClick.RemoveListener(ButtonMainMenu_OnClick);
        }
    }
}
