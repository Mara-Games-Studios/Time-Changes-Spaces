using System;
using UnityEngine;
using UnityEngine.UI;

namespace Death
{
    public class DarkScreenController : MonoBehaviour
    {
        [SerializeField] 
        private Image image;

        [SerializeField] [Range(0, 1)] 
        private float hintValue, deathValue;

        [SerializeField] 
        private float dampingSpeed = 0.01f;

        private bool wasHintActivated, wasDeatActivated;
        private Color imageColor;

        public event Action OnHintOccur;
        public event Action OnDie;

        private void Start()
        {
            imageColor = image.color;
        }

        private void Update()
        {
            imageColor.a += dampingSpeed * Time.deltaTime;
            image.color = imageColor;

            if (imageColor.a > deathValue && !wasDeatActivated)
            {
                wasDeatActivated = true;
                OnDie?.Invoke();
            }
            else if (!wasHintActivated && imageColor.a > hintValue)
            {
                wasHintActivated = true;
                OnHintOccur?.Invoke();
            }
        }
    }
}