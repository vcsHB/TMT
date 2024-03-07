using System.Collections.Generic;
using UnityEngine;

namespace AudioManage
{
    [System.Serializable]
    
    public class AudioPackage : ScriptableObject
    {
        public string packageName;
        [Space(10)]
        public List<AudioCell> audioCells;

    }
}