using Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public enum InGameScene
    {
        MainMenu,
        FirstLevel
    }

    [Serializable]
    public struct InGameSceneWithString
    {
        public InGameScene InGameScene;

        [Scene]
        public string Name;
    }

    [AddComponentMenu("Global.SceneManager")]
    internal class SceneManager : MonoBehaviour
    {
        public static SceneManager Instance = null;

        [SerializeField]
        private List<InGameSceneWithString> inGameScenes;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public void LoadScene(InGameScene inGameScene)
        {
            InGameSceneWithString sceneString = inGameScenes.Find(
                x => x.InGameScene == inGameScene
            );
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneString.Name);
        }
    }
}
