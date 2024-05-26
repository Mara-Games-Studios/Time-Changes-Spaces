using UnityEngine;

namespace Level.Effects
{
    [AddComponentMenu("Level.Effects.Fade")]
    internal class Fade : MonoBehaviour
    {
        [SerializeField]
        private Controller controller;

        [SerializeField]
        private Material screenMaterial;

        [SerializeField]
        private float maxInfectivity;

        [SerializeField]
        private float minInfectivity;

        private const string infectivity_string = "_intensity";

        private void OnEnable()
        {
            controller.OnTimeTick += Controller_OnTimeTick;
        }

        private void OnDisable()
        {
            controller.OnTimeTick -= Controller_OnTimeTick;
        }

        private void Controller_OnTimeTick(uint ticks)
        {
            screenMaterial.SetFloat(
                infectivity_string,
                GetRightSum(0, ticks, controller.MaxStepsToLose, minInfectivity, maxInfectivity)
            );
        }

        private float GetRightSum(float min1, float cur1, float max1, float min2, float max2)
        {
            float cur2 = ((cur1 - min1) * (max2 - min2) / (max1 - min1)) + min2;
            return max2 - cur2;
        }
    }
}
