using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Log;
using Logger = Log.Logger;

public class LoggerTest : MonoBehaviour
{
    void Start()
    {
        Logger.Log("테스트 로그");
        Logger.LogWarning("테스트 로그");
        Logger.LogError("테스트 로그");
        Logger.Log("테스트 로그", Color.blue, true, true);
        Logger.ColorLog("테스트 로그", Color.yellow);
        Logger.RainbowLog("테스트 로그");
        Logger.FileLog("테스트 로그");
    }
}
