﻿using Global;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Death
{
    [AddComponentMenu("Death/Death.DeathScreenController")]
    public class DeathScreenController : MonoBehaviour
    {
        [SerializeField]
        [Header("Death screen settings")]
        private Canvas deathCanvas;

        [SerializeField]
        private Button restartLevelButton;

        [SerializeField]
        [Header("Components")]
        private DarkScreenController screenController;

        [SerializeField]
        private Brain playerBrain;

        private void OnEnable()
        {
            screenController.OnLevelEnd += ShowDeathScreen;
            playerBrain.OnDieOnWrongCell += ShowDeathScreen;
        }

        private void OnDisable()
        {
            screenController.OnLevelEnd -= ShowDeathScreen;
            playerBrain.OnDieOnWrongCell -= ShowDeathScreen;
        }

        public void ShowDeathScreen()
        {
            deathCanvas.gameObject.SetActive(true);
            restartLevelButton.onClick.AddListener(() => SceneManager.Instance.ReloadScene());
        }
    }
}
