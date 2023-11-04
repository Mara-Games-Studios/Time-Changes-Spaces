using UnityEngine;
using UnityEngine.EventSystems;

namespace EducationalPanel
{
    [AddComponentMenu("EducationalPanel.Removing")]
    internal class Removing : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Controller controller;

        public void OnPointerClick(PointerEventData eventData)
        {
            controller.Close();
        }
    }
}
