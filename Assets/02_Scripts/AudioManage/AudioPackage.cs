using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace AudioManage
{
    [System.Serializable]
    
    public class AudioPackage : ScriptableObject
    {
        
        public string packageName;
        [Space(10)]
        public List<AudioCell> audioCells;
        
        
        [CanBeNull]
        public AudioCell GetAudio(int id)
        {
            for (int i = 0; i < audioCells.Count; i++)
            {
                if (id == audioCells[i].id)
                {
                    return audioCells[i];
                }   
            }

            return null;
        }
        
        [CanBeNull]
        public AudioCell GetAudio(string name)
        {
            for (int i = 0; i < audioCells.Count; i++)
            {
                if (name == audioCells[i].name)
                {
                    return audioCells[i];
                }   
            }

            return null;
        }

        
    }
}