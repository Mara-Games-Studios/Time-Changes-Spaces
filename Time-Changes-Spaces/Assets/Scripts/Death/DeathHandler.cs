using Global;
using Player;
using UnityEngine;

namespace Death
{
    public class DeathHandler : MonoBehaviour
    {
        [SerializeField] 
        private DarkScreenController screenController;

        [SerializeField] 
        private Brain playerBrain;

        private void OnEnable()
        {
            screenController.OnDie += Die;
            playerBrain.OnDieOnWrongCell += Die;
        }

        private void OnDisable()
        {
            screenController.OnDie -= Die;
            playerBrain.OnDieOnWrongCell -= Die;
        }

        private void Die()
        {
            SceneManager.Instance.LoadScene(InGameScene.MainMenu);
        }
    }
}