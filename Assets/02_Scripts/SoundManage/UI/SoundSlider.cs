using System;
using UnityEngine;
using UnityEngine.UI;
namespace MINISound
{

    [RequireComponent(typeof(Slider))]
    public class SoundSlider : MonoBehaviour
    {
        [field:SerializeField] public AudioType AudioSettingType {get; private set; }
        public event Action<AudioType, float> OnSliderChangedEvent;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener(HandleVolumeChanged);
        }

        private void HandleVolumeChanged(float value)
        {
            OnSliderChangedEvent?.Invoke(AudioSettingType, value);
        }
    }
}