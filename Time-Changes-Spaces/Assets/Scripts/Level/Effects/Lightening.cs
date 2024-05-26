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
        private float targetIntencity;

        [SerializeField]
        private float targetAlfa;

        private const string infectivity_string = "_intensity";
        private const string alfa_string = "_alfa";

        public void StartLightening(Action nextAction)
        {
            _ = StartCoroutine(MakeScreenDark(nextAction));
        }

        private IEnumerator MakeScreenDark(Action nextAction)
        {
            float time = 0f;
            float intensity = screenMaterial.GetFloat(infectivity_string);
            float startIntensity = intensity;
            float alfa = screenMaterial.GetFloat(alfa_string);
            float startAlfa = alfa;
            while (time < lighteningTime)
            {
                intensity = Mathf.Lerp(startIntensity, targetIntencity, time / lighteningTime);
                alfa = Mathf.Lerp(startAlfa, targetAlfa, time / lighteningTime);
                screenMaterial.SetFloat(infectivity_string, intensity);

                screenMaterial.SetFloat(alfa_string, alfa);
                yield return null;
                time += Time.deltaTime;
            }
            nextAction?.Invoke();
        }
    }
}
