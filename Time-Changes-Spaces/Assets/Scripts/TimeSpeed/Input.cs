using UnityEngine;
using UnityEngine.UI;

namespace TimeSpeed
{
    [AddComponentMenu("TimeSpeed.Input")]
    internal class Input : MonoBehaviour
    {
        [SerializeField]
        private Controller controller;

        [SerializeField]
        private Button slowButton;

        [SerializeField]
        private Button normalButton;

        [SerializeField]
        private Button fastButton;

        private void OnEnable()
        {
            slowButton.onClick.AddListener(OnSlowButtonClick);
            normalButton.onClick.AddListener(OnNormalButtonClick);
            fastButton.onClick.AddListener(OnFastButtonClick);
        }

        private void OnSlowButtonClick()
        {
            controller.SetTimeState(TimeState.Slow);
        }

        private void OnNormalButtonClick()
        {
            controller.SetTimeState(TimeState.Normal);
        }

        private void OnFastButtonClick()
        {
            controller.SetTimeState(TimeState.Fast);
        }

        private void OnDisable()
        {
            slowButton.onClick.RemoveListener(OnSlowButtonClick);
            normalButton.onClick.RemoveListener(OnNormalButtonClick);
            fastButton.onClick.RemoveListener(OnFastButtonClick);
        }
    }
}
