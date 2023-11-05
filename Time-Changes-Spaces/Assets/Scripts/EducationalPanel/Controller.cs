using UnityEngine;

namespace EducationalPanel
{
    [AddComponentMenu("EducationalPanel.Controller")]
    internal class Controller : MonoBehaviour
    {
        [SerializeField]
        private GameObject educationalCanvas;

        public void Open()
        {
            educationalCanvas.SetActive(true);
        }

        public void Close()
        {
            educationalCanvas.SetActive(false);
        }
    }
}
