using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioManage
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "SO/AudioManage/AudioCell")]
    public class AudioCell : ScriptableObject
    {
        public AudioType audioType;
        public AudioSource audioSource;
        
    }
}
