using Common;
using Death;
using Global;
using Player;
using System;
using UnityEngine;

namespace Level
{
    [AddComponentMenu("Level.Controller")]
    internal class Controller : MonoBehaviour
    {
        [Scene]
        [SerializeField]
        private string nextScene;

        [SerializeField]
        private Movement movement;

        [SerializeField]
        private TileMap.Controller tileMapController;

        [SerializeField]
        private Brain brain;

        [SerializeField]
        private TimeSpeed.Controller timeSpeedController;

        [SerializeField]
        private uint stepsToLose;
        private uint maxStepsToLose;
        public uint MaxStepsToLose => maxStepsToLose;

        [SerializeField]
        private Settings.Controller settingsController;

        [SerializeField]
        private EducationalPanel.Controller educationalPanelController;

        [SerializeField]
        private DeathScreenController deathScreenController;

        [SerializeField]
        private Effects.Lightening lighteningEffect;

        [SerializeField]
        private AudioSource scarySound;

        public event Action<uint> OnTimeTick;

        private void Awake()
        {
            maxStepsToLose = stepsToLose;
        }

        private void OnEnable()
        {
            tileMapController.OnDictionaryFilled += TileMapController_OnDictionaryFilled;
            brain.OnTryMove += Brain_OnTryMove;
            timeSpeedController.OnTimeStateChanged += timeState => TickTime();
        }

        public void Win()
        {
            lighteningEffect.StartLightening(() => SceneManager.Instance.LoadScene(nextScene));
        }

        public void OpenSettings()
        {
            settingsController.Open();
        }

        public void OpenEducationalPanel()
        {
            educationalPanelController.Open();
        }

        private void TileMapController_OnDictionaryFilled()
        {
            movement.SetPosition(tileMapController.StartPointPosition);
        }

        private void Brain_OnTryMove(bool isAllowed)
        {
            TickTime();
        }

        private void TickTime()
        {
            stepsToLose--;
            OnTimeTick?.Invoke(stepsToLose);
            if (stepsToLose == 25)
            {
                scarySound.Play();
            }
            if (stepsToLose == 0)
            {
                deathScreenController.ShowDeathScreen();
            }
        }

        private void OnDisable()
        {
            tileMapController.OnDictionaryFilled -= TileMapController_OnDictionaryFilled;
            brain.OnTryMove -= Brain_OnTryMove;
            timeSpeedController.OnTimeStateChanged -= timeState => TickTime();
        }
    }
}
