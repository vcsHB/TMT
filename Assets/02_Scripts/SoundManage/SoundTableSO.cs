using System.Collections.Generic;
using UnityEngine;

namespace MINISound
{
    [CreateAssetMenu(menuName = "TMT/SO/MINISound/SoundTableSO")]
    public class SoundTableSO : ScriptableObject
    {
        public AudioType audioType;
        public List<SoundSO> soundSOList;
    }
}