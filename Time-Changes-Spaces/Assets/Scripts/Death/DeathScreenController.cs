using Global;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Death
{
    [AddComponentMenu("Death/Death.DeathScreenController")]
    public class DeathScreenController : MonoBehaviour
    {
        [SerializeField] [Header("Death screen settings")]
        private Canvas deathCanvas;

        [SerializeField] 
        private Button restartLevelButton;
        
        [SerializeField] [Header("Components")]
        private DarkScreenController screenController;

        [SerializeField] 
        private Brain playerBrain;

        private void OnEnable()
        {
            screenController.OnLevelEnd += ShowDeathCanvas;
            playerBrain.OnDieOnWrongCell += ShowDeathCanvas;
        }

        private void OnDisable()
        {
            screenController.OnLevelEnd -= ShowDeathCanvas;
            playerBrain.OnDieOnWrongCell -= ShowDeathCanvas;
        }

        private void ShowDeathCanvas()
        {
            deathCanvas.gameObject.SetActive(true);
            restartLevelButton.onClick.AddListener(() => SceneManager.Instance.LoadScene(InGameScene.FirstLevel));
        }

        private void CloseDeathScreen()
        {
            restartLevelButton.onClick.RemoveListener(() => SceneManager.Instance.LoadScene(InGameScene.FirstLevel));
            deathCanvas.gameObject.SetActive(false);
        }
    }
}