using UnityEngine;

namespace EducationalPanel
{
    [AddComponentMenu("EducationalPanel.Controller")]
    internal class Controller : MonoBehaviour
    {
        [SerializeField]
        private GameObject panel;

        public void Open()
        {
            panel.SetActive(true);
        }

        public void Close()
        {
            panel.SetActive(false);
        }
    }
}
