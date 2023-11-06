using UnityEngine;
using UnityEngine.EventSystems;

namespace FinalLevel
{
    [AddComponentMenu("FinalLevel.Input")]
    internal class Input : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Controller controller;

        public void OnPointerClick(PointerEventData eventData)
        {
            controller.LoadMenu();
        }
    }
}
