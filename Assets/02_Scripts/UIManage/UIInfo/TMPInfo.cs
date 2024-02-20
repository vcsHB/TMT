using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace UIManage
{
    public enum ValueType
    {
        Int,
        String,
        Float,
        
    }
    public struct ContentSegment
    {
        public TextContent[] contents;
        
    }
    

    public struct TextContent
    {
        public string content;
        public float term;
        public bool isReWrite;

    }

    public struct InsertContent
    {
        public ValueType valueType;
        public int intValue;
        public string stringValue;
        public float floatValue;
        public bool boolValue;
    }

    /**
     * 이 클래스는 TextMeshProGUI를 다루는 2D용 TMP 스크립트임
     */

    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TMPInfo : MonoBehaviour
    {
        public static TextMeshProUGUI _TMP;


        [Tooltip("'<$v>' 로 content 중간중간에 삽입할 위치 표시")] public string content;

        public object[] insertValue;


        private void Awake()
        {
            try
            {
                _TMP = GetComponent<TextMeshProUGUI>();

            }
            catch (Exception e)
            {
                Debug.Log(e);
                Debug.Log("<color=red>[ TMPInfo ] 컴포넌트에 TMP가 없습니다 </color>");
                throw;
            }
        }
        
        public void RefreshInsert()
        {
            string insertedContent = content;
            for (int i = 0; i < insertValue.Length; i++)
            {
                if (content.IndexOf("<$v>") != -1)
                {
                    insertedContent.Replace("<$v>", insertValue[i]);
                }
                else
                {
                    return;
                }
            }
            _TMP.text = 

        }

        /**
         * <summary>
         * Text 재작성 메서드
         * </summary>
         */
        public void Write(string content)
        {
            _TMP.text = content;
        }

        /**
         * <summary>
         * Text 재작성 메서드, Duration으로 출력할 시간을 입력 할 수 있다
         * </summary>
         */
        public void Write(string content, float duration)
        {
            _TMP.text = "";
            StartCoroutine(WriteRoutine(content, duration));
        }

        /**
         * <summary>
         * Text 추가 작성 메서드
         * </summary>
         */
        public void AddWrite(string content)
        {
            _TMP.text += content;
        }

        /**
         * <summary>
         * Text 추가 작성 메서드,  Duration으로 출력할 시간을 입력 할 수 있다
         * </summary>
         */
        public void AddWrite(string content, float duration)
        {
            if (duration <= 0)
            {
                AddWrite(content);
                return;
            }

            StartCoroutine(WriteRoutine(content, duration));
        }

        private IEnumerator WriteRoutine(string content, float duration)
        {
            float term = Mathf.Clamp(duration / content.Length, 0f, 10f);
            foreach (var word in content)
            {
                _TMP.text += word.ToString();
                yield return new WaitForSeconds(term);

            }

        }
    }

}
