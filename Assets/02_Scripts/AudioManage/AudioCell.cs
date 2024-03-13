using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioManage
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "SO/AudioManage/AudioCell")]
    
    public class AudioCell : ScriptableObject
    {
        public int id;
        public string audioName = "Audio_";
        public AudioType audioType;
        public AudioSource audioSource;
        
    }
}
