using TMPro;
using UnityEngine;

namespace TimeSpeed
{
    [AddComponentMenu("TimeSpeed.View")]
    internal class View : MonoBehaviour
    {
        [SerializeField]
        private Controller controller;

        [SerializeField]
        private TMP_Text label;

        private void OnEnable()
        {
            controller.OnTimeStateChanged += ChangeState;
        }
        
        private void OnDisable()
        {
            controller.OnTimeStateChanged -= ChangeState;
        }

        private void ChangeState(TimeState timeState)
        {
            label.text = timeState.ToString();
        }
    }
}
