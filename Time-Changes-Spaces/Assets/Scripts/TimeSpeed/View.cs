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

        private void Update()
        {
            label.text = controller.CurrentTimeState switch
            {
                TimeState.Fast => "Fast",
                TimeState.Normal => "Normal",
                TimeState.Slow => "Slow",
                _ => "Undefined"
            };
        }
    }
}
