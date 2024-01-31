using System;
using DG.Tweening;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInfo : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    /**
     * <summary>
     * UI이름
     * </summary>
     */
    public string UIName;
    /**
     * <summary>
     * 움직일 UI RectTransform
     * </summary>
     */
    public RectTransform UI_Transform;

    [Tooltip("처음 위치")]
    public Vector2 DefaultPos;
    [Tooltip("Move이벤트로 움직일 위치")]
    public Vector2 TargetPos;
    [Tooltip("움직이는 시간")]
    public float duration;
    [Tooltip("움직일 때 Easing 효과")]
    public Ease EaseEffect = Ease.Linear;
    [Tooltip("UI의 On/Off")]
    public bool onOff;

    public bool useColorEffect = false;
    [Tooltip("처음 색")]
    public Color DefaultColor = Color.white;
    [Tooltip("변할 색")]
    public Color TargetColor = Color.gray;
    [Tooltip("변하는 시간")]
    public float ColorEffectDuration;
    public bool colorOnOff;
    [Tooltip("색 Easing 효과")]
    public Ease ColorEaseEffect = Ease.Linear;

    public bool isButton;
    public bool isDetectMouse;

    [Header("Click Event")]
    public UnityEvent OnClick;
    [Header("Mouse Event")]
    public UnityEvent OnMouseEnter;
    public UnityEvent OnMouseExit;


    private void Awake()
    {
        NullCheck();
        
        
    }

    /**
     * <summary>
     * 자동 UI OnOff
     * </summary>
     */
    public void MovePos()
    {
        

        if (!onOff)
        {
            UI_Transform.DOAnchorPos(TargetPos, duration);
            onOff = true;
        }
        else
        {
            UI_Transform.DOAnchorPos(DefaultPos, duration);
            onOff = false;
        }
    }
    /**
     * <summary>
     * UI 키기
     * </summary>
     */
    public void MoveOn()
    {
        if (!onOff)
        {
            UI_Transform.DOAnchorPos(TargetPos, duration).SetEase(EaseEffect);
            onOff = true;
        }
    }

    /**
     * <summary>
     * UI 끄기
     * </summary>
     */
    public void MoveOff()
    {
        if (onOff)
        {
            UI_Transform.DOAnchorPos(DefaultPos, duration).SetEase(EaseEffect);
            onOff = false;
        }
    }

    public void ChangeColor()
    {
        if (useColorEffect)
        {
            
            if (colorOnOff)
            {
                OffColor();
            }
            else
            {
                OnColor();
            }
        }
    }

    public void OnColor()
    {
        if (!useColorEffect)
        {
            return;
        }
        if (!colorOnOff)
        {
            UI_Transform.GetComponent<Image>().DOColor(TargetColor, ColorEffectDuration).SetEase(ColorEaseEffect);
            colorOnOff = true;
        }
    }
    public void OffColor()
    {
        if (!useColorEffect)
        {
            return;
        }
        if (colorOnOff)
        {
            UI_Transform.GetComponent<Image>().DOColor(DefaultColor, ColorEffectDuration).SetEase(ColorEaseEffect);
            colorOnOff = false;
        }
    }
    

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isButton)
        {
            OnClick?.Invoke();
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isDetectMouse)
        {
            OnMouseEnter?.Invoke();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isDetectMouse)
        {
            OnMouseExit?.Invoke();
        }
    }

    private void NullCheck()
    {
        {
            Debug.LogWarning("duration은 0보다 커야합니다.");
        }
        if (UI_Transform == null)
        {
            Debug.LogWarning("[] UI_Transform이 null입니다.");
            
            // 설정해주지 않은 경우 본인 오브젝트로 지정
            UI_Transform = transform.GetComponent<RectTransform>();
        }
    }
}

