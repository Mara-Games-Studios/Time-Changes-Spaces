using CameraShake;
using Global;
using Player;
using System;
using System.Collections;
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
                LockerUI.Instance.LockScreen();
                _ = StartCoroutine(DoAfterWait(0.5f, () => LockerUI.Instance.UnLockScreen()));
            }
        }

        private IEnumerator DoAfterWait(float time, Action action)
        {
            float timer = 0;
            while (timer < time)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            action?.Invoke();
        }
    }
}
