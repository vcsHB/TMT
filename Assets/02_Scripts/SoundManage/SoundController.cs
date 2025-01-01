using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
namespace MINISound
{


    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private SoundSlider[] _audioSliders;
        private Dictionary<AudioType, > _sliderDictionary;


        private void Awake()
        {

        }



    }
}