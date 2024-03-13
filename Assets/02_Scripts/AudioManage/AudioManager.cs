using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioManage
{
    
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioPackage _audioPackage;

        public void SoundPlay(int id)
        {
            if (_audioPackage.GetAudio(id) == null)
            {
                return;
            }
            AudioCell audioCell = _audioPackage.GetAudio(id);
        }
        
        public void SoundPlay(string name)
        {
            
        }
    }
}
