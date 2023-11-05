using UnityEngine;

namespace TimeSpeed
{
    [AddComponentMenu("TimeSpeed.View")]
    internal class View : MonoBehaviour
    {
        [SerializeField]
        private Controller controller;

        [SerializeField]
        private GameObject fastClock;

        [SerializeField]
        private GameObject normalClock;

        [SerializeField]
        private GameObject slowClock;

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
            switch (timeState)
            {
                case TimeState.Fast:
                    fastClock.SetActive(true);
                    normalClock.SetActive(false);
                    slowClock.SetActive(false);
                    break;
                case TimeState.Normal:
                    fastClock.SetActive(false);
                    normalClock.SetActive(true);
                    slowClock.SetActive(false);
                    break;
                case TimeState.Slow:
                    fastClock.SetActive(false);
                    normalClock.SetActive(false);
                    slowClock.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}
