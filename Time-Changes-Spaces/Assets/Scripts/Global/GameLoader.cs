﻿using UnityEngine;

namespace Global
{
    [AddComponentMenu("Global.GameLoader")]
    public class GameLoader : MonoBehaviour
    {
        [SerializeField]
        private SceneManager sceneManagerPrefab;

        [SerializeField]
        private AudioManager audioManagerPrefab;

        [SerializeField]
        private LockerUI lockerUIPrefab;

        private void Awake()
        {
            if (SceneManager.Instance == null)
            {
                _ = Instantiate(sceneManagerPrefab);
            }

            if (AudioManager.Instance == null)
            {
                _ = Instantiate(audioManagerPrefab);
            }

            if (LockerUI.Instance == null)
            {
                _ = Instantiate(lockerUIPrefab);
            }
        }
    }
}
