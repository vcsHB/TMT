using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
namespace MINISound
{
    public class SoundSequencer : MonoBehaviour
    {
        [Header("Sequence Setting")]
        [SerializeField] private float _sequenceTerm;
        [SerializeField] private bool _isLoopSequence;
        [SerializeField] private bool _useChangeEffect;
        [SerializeField] private float _fadeLength = 1f;

        public List<SoundSO> bgmList;

        private AudioSource _currentAudioPlayer;
        private AudioSource[] _audioPlayers;
        [Header("Current State")]
        [SerializeField] private int _playerIndex = 0;
        [SerializeField] private int _bgmIndex = -1; // -1로 시작해야 0번부터 자동으로 시작된다.



        private void Awake()
        {
            _audioPlayers = GetComponentsInChildren<AudioSource>();
        }

        #region External Functions

        public void Play()
        {

        }

        public void ForceChangeBGM()
        {


        }

        #endregion


        private void EndAudio()
        {
            if (_useChangeEffect)
                _currentAudioPlayer.DOFade(0f, _fadeLength);
            else
                _currentAudioPlayer.Stop();
        }
        private void PlayNextAudio()
        {
            _playerIndex = (_playerIndex + 1) % _audioPlayers.Length;

            if (_isLoopSequence)
                _bgmIndex = (_bgmIndex + 1) % bgmList.Count;
            else if (_bgmIndex + 1 >= bgmList.Count)
                return;

            if (_useChangeEffect)
            {
                _currentAudioPlayer = _audioPlayers[_playerIndex];
                _currentAudioPlayer.clip = bgmList[_bgmIndex].clip;
                _currentAudioPlayer.Play();
                _currentAudioPlayer.DOFade(1f, _fadeLength);
            }
            else
            {
                _currentAudioPlayer.Play();
                
            }
        }
    }

}