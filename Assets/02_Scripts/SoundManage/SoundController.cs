using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
namespace MINISound
{


    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private SoundSlider[] _audioSliders;
        private Dictionary<AudioType, List<SoundSlider>> _sliderDictionary;

        private readonly float _volumeMin = -40f;
        private readonly float _volumeMax = 0f;
        private void Awake()
        {
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            _sliderDictionary = new();

            for (int i = 0; i < _audioSliders.Length; i++)
            {
                SoundSlider slider = _audioSliders[i];
                slider.OnSliderChangedEvent += HandleSliderValueChanged;
                if (_sliderDictionary.ContainsKey(slider.AudioSettingType))
                    _sliderDictionary.Add(slider.AudioSettingType, new List<SoundSlider>());
                if (_sliderDictionary.TryGetValue(slider.AudioSettingType, out List<SoundSlider> list))
                {
                    list.Add(slider);
                }
            }
        }

        private void HandleSliderValueChanged(AudioType type, float value)
        {
            value = Mathf.Clamp(value, _volumeMin, _volumeMax);
            _audioMixer.SetFloat($"{type.ToString()}_Volume", value);

        }

        public void SetVolume(AudioType type, float value)
        {
            HandleSliderValueChanged(type, value);
        }
    }
}