using UnityEngine;

namespace TimeSpeed
{
    [AddComponentMenu("TimeSpeed.Input")]
    internal class Input : MonoBehaviour
    {
        [Header("KB")]
        [SerializeField]
        private KeyCode slowKB;

        [SerializeField]
        private KeyCode normalKB;

        [SerializeField]
        private KeyCode fastKB;

        [SerializeField]
        private Controller controller;

        //[SerializeField]
        //private Button slowButton;

        //[SerializeField]
        //private Button normalButton;

        //[SerializeField]
        //private Button fastButton;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(slowKB))
            {
                OnSlowButtonClick();
            }
            if (UnityEngine.Input.GetKeyDown(normalKB))
            {
                controller.SetTimeState(TimeState.Normal);
            }
            if (UnityEngine.Input.GetKeyDown(fastKB))
            {
                OnFastButtonClick();
            }
        }

        //private void OnEnable()
        //{
        //    slowButton.onClick.AddListener(OnSlowButtonClick);
        //    normalButton.onClick.AddListener(OnNormalButtonClick);
        //    fastButton.onClick.AddListener(OnFastButtonClick);
        //}

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

        //private void OnDisable()
        //{
        //    slowButton.onClick.RemoveListener(OnSlowButtonClick);
        //    normalButton.onClick.RemoveListener(OnNormalButtonClick);
        //    fastButton.onClick.RemoveListener(OnFastButtonClick);
        //}
    }
}
