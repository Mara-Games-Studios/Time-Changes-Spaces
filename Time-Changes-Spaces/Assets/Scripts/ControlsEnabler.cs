using UnityEngine;

namespace Scripts
{
    [AddComponentMenu("Scripts/Scripts/ControlsEnabler")]
    internal class ControlsEnabler : MonoBehaviour
    {
        private bool isMobile = false;

        [SerializeField]
        private GameObject toActivate;

#if !UNITY_EDITOR && UNITY_WEBGL
        [System.Runtime.InteropServices.DllImport("__Internal")]
        static extern bool IsMobile();
#endif

        private void CheckIfMobile()
        {
#if !UNITY_EDITOR && UNITY_WEBGL
            isMobile = IsMobile();
#endif
        }

        private void Start()
        {
            CheckIfMobile();
            if (isMobile)
            {
                toActivate.SetActive(true);
            }
        }
    }
}
