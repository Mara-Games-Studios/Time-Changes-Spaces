using CameraShake;
using Player;
using UnityEngine;

namespace Level
{
    public class CamShake : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private Brain brain;

        private void OnEnable()
        {
            brain.OnTryMove += Small2DShake;
        }

        private void OnDisable()
        {
            brain.OnTryMove -= Small2DShake;
        }

        private void Small2DShake(bool canMove)
        {
            if (!canMove)
            {
                CameraShaker.Presets.Explosion2D();
            }
        }
    }
}
