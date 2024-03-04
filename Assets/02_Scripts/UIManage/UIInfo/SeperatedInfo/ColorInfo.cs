using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UIManage;
using UnityEngine;

public class ColorInfo : Info
{
    
    [Tooltip("처음 색")] public Color DefaultColor = Color.white;
    [Tooltip("변할 색")] public Color TargetColor = Color.gray;
    [Tooltip("변하는 시간")] public float ColorEffectDuration;
    public bool colorOnOff;
    [Tooltip("색 Easing 효과")] public Ease ColorEaseEffect = Ease.Linear;


}
