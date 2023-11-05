using System;
using System.Collections;
using UnityEngine;

namespace Level.Effects
{
    [AddComponentMenu("Level.Effects.Lightening")]
    internal class Lightening : MonoBehaviour
    {
        [SerializeField]
        private float lighteningTime;

        [SerializeField]
        private Material screenMaterial;

        [SerializeField]
        private float maxInfectivity;

        [SerializeField]
        private float minInfectivity;

        [SerializeField]
        private float maxAlfa;

        [SerializeField]
        private float minAlfa;

        private const string infectivity_string = "_intencity";
        private const string alfa_string = "_alfa";

        public void StartLightening(Action nextAction)
        {
            _ = StartCoroutine(MakeScreenDark(nextAction));
        }

        private IEnumerator MakeScreenDark(Action nextAction)
        {
            float time = 0f;
            while (time < lighteningTime)
            {
                screenMaterial.SetFloat(
                    infectivity_string,
                    GetRightSum(0, time, lighteningTime, minInfectivity, maxInfectivity)
                );

                screenMaterial.SetFloat(
                    alfa_string,
                    GetLeftSum(0, time, lighteningTime, minAlfa, maxAlfa)
                );
                yield return null;
                time += Time.deltaTime;
            }
            nextAction?.Invoke();
        }

        private float GetRightSum(float min1, float cur1, float max1, float min2, float max2)
        {
            float cur2 = ((cur1 - min1) * (max2 - min2) / (max1 - min1)) + min2;
            return max2 - cur2;
        }

        private float GetLeftSum(float min1, float cur1, float max1, float min2, float max2)
        {
            float cur2 = ((cur1 - min1) * (max2 - min2) / (max1 - min1)) + min2;
            return cur2 - min1;
        }
    }
}
