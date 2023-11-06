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

        private const string infectivity_string = "_intencity";
        private const string alfa_string = "_alfa";

        public void StartLightening(Action nextAction)
        {
            _ = StartCoroutine(MakeScreenDark(nextAction));
        }

        private IEnumerator MakeScreenDark(Action nextAction)
        {
            float time = 0f;
            float intencity = screenMaterial.GetFloat(infectivity_string);
            float startIntencity = intencity;
            float alfa = screenMaterial.GetFloat(alfa_string);
            float startAlfa = alfa;
            while (time < lighteningTime)
            {
                intencity = Mathf.Lerp(startIntencity, targetIntencity, time / lighteningTime);
                alfa = Mathf.Lerp(startAlfa, targetAlfa, time / lighteningTime);
                screenMaterial.SetFloat(infectivity_string, intencity);

                screenMaterial.SetFloat(alfa_string, alfa);
                yield return null;
                time += Time.deltaTime;
            }
            nextAction?.Invoke();
        }
    }
}
