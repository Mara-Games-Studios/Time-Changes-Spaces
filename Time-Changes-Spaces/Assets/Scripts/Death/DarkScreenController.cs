using Player;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Death
{
    [AddComponentMenu("Death/Death.DarkScreenController")]
    public class DarkScreenController : MonoBehaviour
    {
        [SerializeField] [Header("Damping settings")]
        private Image darkImage;

        [SerializeField] [Range(0, 1)] 
        private float hintValue, deathValue;

        [SerializeField] 
        private float dampingSpeed = 0.01f;

        [SerializeField] [Header("Components settings")]
        private Brain playerBrain;

        private Color imageColor;
        private const float timeToBlackScreen = 1f;
        private bool wasHintActivated, wasDeathActivated;

        public event Action OnHintOccur, OnLooseGame, OnLevelEnd;
        
        private void Start()
        {
            imageColor = darkImage.color;
        }

        private void OnEnable()
        {
            playerBrain.OnDieOnWrongCell += Die;
        }

        private void OnDisable()
        {
            playerBrain.OnDieOnWrongCell -= Die;
        }

        private void Update()
        {
            if(wasDeathActivated)
                return;
            
            imageColor.a += dampingSpeed * Time.deltaTime;
            darkImage.color = imageColor;

            if (imageColor.a > deathValue && !wasDeathActivated)
            {
                Die();
            }
            else if (!wasHintActivated && imageColor.a > hintValue)
            {
                wasHintActivated = true;
                OnHintOccur?.Invoke();
            }
        }

        private void Die()
        {
            wasDeathActivated = true;
            OnLooseGame?.Invoke();
            StartCoroutine(MakeScreenDark());
        }

        private IEnumerator MakeScreenDark()
        {
            float time = 0f;
            while (time < timeToBlackScreen)
            {
                darkImage.color = Color.Lerp(imageColor, Color.black, time);
                time += Time.deltaTime;
                yield return null;
            }
            OnLevelEnd?.Invoke();   
        }
    }
}