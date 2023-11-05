using Common;
using TimeSpeed;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Level
{
    [AddComponentMenu("Scripts/Level/Effects/Level.TimeChangeVolume")]
    public class TimeChangeVolume : MonoBehaviour
    {
        [SerializeField]
        private TimeSpeed.Controller timeController;

        [SerializeField]
        private float countSpeed = 1.5f;

        [SerializeField]
        [InspectorReadOnly]
        private bool fadeIn = true;

        [SerializeField]
        [InspectorReadOnly]
        private TimeState prevTimeState;

        [SerializeField]
        private Volume volume;

        [SerializeField]
        [InspectorReadOnly]
        private LensDistortion distortion;

        private void Awake()
        {
            if (volume.sharedProfile.TryGet(out LensDistortion ld))
            {
                distortion = ld;
            }
        }

        private void OnEnable()
        {
            timeController.OnTimeStateChanged += ChangeDistortion;
        }

        private void OnDisable()
        {
            timeController.OnTimeStateChanged -= ChangeDistortion;
        }

        private void Update()
        {
            TriggerVolumeEffect();
        }

        private void ChangeDistortion(TimeState timeState)
        {
            switch (timeState)
            {
                case TimeState.Slow:
                    distortion.intensity.value = 1.0f;
                    break;
                case TimeState.Normal:
                    distortion.intensity.value = 0.0f;
                    break;
                case TimeState.Fast:
                    distortion.intensity.value = -1.0f;
                    break;
            }
            if (prevTimeState != timeState)
            {
                fadeIn = false;
                prevTimeState = timeState;
            }
        }

        private void TriggerVolumeEffect()
        {
            if (fadeIn)
            {
                VolumeWeightMinus();
            }

            if (!fadeIn)
            {
                VolumeWeightPlus();
            }
        }

        private void VolumeWeightMinus()
        {
            if (volume != null && volume.weight > 0.05f)
            {
                volume.weight -= Time.deltaTime * countSpeed;
                if (volume.weight <= 0.1f)
                {
                    return;
                }
            }
        }

        private void VolumeWeightPlus()
        {
            if (volume != null && volume.weight < 0.95f)
            {
                volume.weight += Time.deltaTime * countSpeed;
                if (volume.weight >= 0.9f)
                {
                    fadeIn = !fadeIn;
                }
            }
        }
    }
}
