using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeManage
{
    
    public class TimeManager
    {
        public static float GlobalTimeScale = 1;
        public static float UITimeScale = 1;
        const float DEFAULT_TIME_SCALE = 1;
        

        public static void GlobalTimeStop()
        {
            GlobalTimeScale = 0;
            
        }
        public static void UITimeStop()
        {
            UITimeScale = 0;
            
        }
        
        public static void SetUITimeScaleDefault()
        {
            UITimeScale = DEFAULT_TIME_SCALE;
        }

        public static void SetGlobalTimeScaleDefault()
        {
            GlobalTimeScale = DEFAULT_TIME_SCALE;
        }

        public static void SpeedUp(float speedValue)
        {
            GlobalTimeScale *= speedValue;
        }
    }
}
