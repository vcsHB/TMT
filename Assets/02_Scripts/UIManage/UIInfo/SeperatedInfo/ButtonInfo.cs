using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIManage
{
    
    public class ButtonInfo : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        
        [Header("Click Event")] public UISequence[] OnClick;
        [Header("Mouse Event")] 
        public UISequence[] OnMouseEnter;
        public UISequence[] OnMouseExit;

        public void OnPointerClick(PointerEventData eventData)
        {
            StartCoroutine(OnClickSequenceRoutine());
        }

        private IEnumerator OnClickSequenceRoutine()
        {
            for (int i = 0; i < OnClick.Length; i++)
            {
                yield return new WaitForSeconds(OnClick[i].beforeDelay);

                OnClick[i].indexedEvent?.Invoke();
            }
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            StartCoroutine(OnMouseEnterSequenceRoutine());
        }
        
        private IEnumerator OnMouseEnterSequenceRoutine()
        {
            for (int i = 0; i < OnMouseEnter.Length; i++)
            {
                yield return new WaitForSeconds(OnMouseEnter[i].beforeDelay);

                OnMouseEnter[i].indexedEvent?.Invoke();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            StartCoroutine(OnMouseExitSequenceRoutine());
        }
        private IEnumerator OnMouseExitSequenceRoutine()
        {
            for (int i = 0; i < OnMouseExit.Length; i++)
            {
                yield return new WaitForSeconds(OnMouseExit[i].beforeDelay);

                OnMouseExit[i].indexedEvent?.Invoke();
            }
        }
    }
}
