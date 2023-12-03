using System;
using System.Collections;
using System.Reflection;

namespace UnityEngine.Tweening
{
    public enum EasingType
    {
        EaseInSine,    EaseOutSine,    EaseInOutSine,
        EaseInCubic,   EaseOutCubic,   EaseInOutCubic,
        EaseInQuint,   EaseOutQuint,   EaseInOutQuint,
        EaseInCirc,    EaseOutCirc,    EaseInOutCirc,
        EaseInElastic, EaseOutElastic, EaseInOutElastic,
        EaseInQuad,    EaseOutQuad,    EaseInOutQuad,
        EaseInQuart,   EaseOutQuart,   EaseInOutQuart,
        EaseInExpo,    EaseOutExpo,    EaseInOutExpo, 
        EaseInBack,    EaseOutBack,    EaseInOutBack,
        EaseInBounce,  EaseOutBounce,  EaseInOutBounce
    }
    
    public class  Tweening : MonoSingleton<Tweening>
    {
        public void DOMove(Transform transform, Vector3 endPoint, float duration, EasingType easing)
        {
            StartCoroutine(Move(transform, endPoint, duration, easing));
        }
        public void DOMove(Transform transform, Vector3 endPoint, float duration, IEnumerator lateCoroutine, EasingType easing)
        {
            StartCoroutine(Move(transform, endPoint, duration, lateCoroutine,easing));
        }
        public void DOMove(Rigidbody rigidbody, Vector3 endPoint, float duration, EasingType easing)
        {
            StartCoroutine(Move(rigidbody, endPoint, duration, easing));
        }
        
        public void DOMove(Rigidbody rigidbody, Vector3 endPoint, float duration, IEnumerator lateCoroutine, EasingType easing)
        {
            StartCoroutine(Move(rigidbody, endPoint, duration, lateCoroutine, easing));
        }
        
        private IEnumerator Move(Transform transform, Vector3 endPoint, float duration, EasingType easing)
        {
            float currentTime = 0;
            float percentTime = 0;
            
            Vector3 startPoint = transform.position;
            Type thisClassType = typeof(Tweening);
            string funcName = easing.ToString();
            MethodInfo easingFunc = thisClassType.GetMethod(funcName, BindingFlags.NonPublic | BindingFlags.Instance);
            
            
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                percentTime = currentTime / duration;
                if(easingFunc != null)
                {
                    transform.localPosition = Vector3.Lerp(startPoint, endPoint, (float)(easingFunc.Invoke(this, new object[]{percentTime})));
                }
                yield return null;
            }
            transform.localPosition = endPoint;
        }
        private IEnumerator Move(Transform transform, Vector3 endPoint, float duration, IEnumerator lateCoroutine, EasingType easing)
        {
            float currentTime = 0;
            float percentTime = 0;
            
            Vector3 startPoint = transform.position;
            Type thisClassType = typeof(Tweening);
            string funcName = easing.ToString();
            MethodInfo easingFunc = thisClassType.GetMethod(funcName, BindingFlags.NonPublic | BindingFlags.Instance);
            
            
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                percentTime = currentTime / duration;
                if(easingFunc != null)
                {
                    transform.localPosition = Vector3.Lerp(startPoint, endPoint, (float)(easingFunc.Invoke(this, new object[]{percentTime})));
                }
                yield return null;
            }
            transform.localPosition = endPoint;

            yield return StartCoroutine(lateCoroutine);
        }
        private IEnumerator Move(Rigidbody rigidbody, Vector3 endPoint, float duration, EasingType easing)
        {
            float currentTime = 0;
            float percentTime = 0;
            
            Vector3 startPoint = rigidbody.position;
            Type thisClassType = typeof(Tweening);
            string funcName = easing.ToString();
            MethodInfo easingFunc = thisClassType.GetMethod(funcName, BindingFlags.NonPublic | BindingFlags.Instance);
            
            
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                percentTime = currentTime / duration;
                if(easingFunc != null)
                {
                    rigidbody.position = Vector3.Lerp(startPoint, endPoint, (float)(easingFunc.Invoke(this, new object[]{percentTime})));
                }
                rigidbody.position = endPoint;
                yield return null;
            }
        }

        private IEnumerator Move(Rigidbody rigidbody, Vector3 endPoint, float duration, IEnumerator lateCoroutine, EasingType easing)
        {
            float currentTime = 0;
            float percentTime = 0;
            
            Vector3 startPoint = rigidbody.position;
            Type thisClassType = typeof(Tweening);
            string funcName = easing.ToString();
            MethodInfo easingFunc = thisClassType.GetMethod(funcName, BindingFlags.NonPublic | BindingFlags.Instance);
            
            
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                percentTime = currentTime / duration;
                if(easingFunc != null)
                {
                    rigidbody.position = Vector3.Lerp(startPoint, endPoint, (float)(easingFunc.Invoke(this, new object[]{percentTime})));
                }
                yield return null;
            }
            rigidbody.position = endPoint;

            yield return StartCoroutine(lateCoroutine);
        }

        #region EaseTypes
        // Sine
        private float EaseInSine(float x)
        {
            return 1 - Mathf.Cos((x * Mathf.PI) / 2);
        }
        private float EaseOutSine(float x)
        {
            return Mathf.Sin((x * Mathf.PI) / 2);
        }
        private float EaseInOutSine(float x)
        {
            return -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
        }
        
        // Cubic
        private float EaseInCubic(float x)
        {
            return x * x * x;
        }
        private float EaseOutCubic(float x)
        {
            return 1 - Mathf.Pow(1 - x, 3);
        }
        private float EaseInOutCubic(float x)
        {
            return x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;
        }
        
        // Quint
        private float EaseInQuint(float x)
        {
            return x * x * x * x * x;
        }
        private float EaseOutQuint(float x)
        {
            return 1 - Mathf.Pow(1 - x, 5);
        }
        private float EaseInOutQuint(float x)
        {
            return x < 0.5 ? 16 * x * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 5) / 2;
        }
        
        // Circ
        private float EaseInCirc(float x)
        {
            return 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));
        }
        private float EaseOutCirc(float x)
        {
            return Mathf.Sqrt(1 - Mathf.Pow(x - 1, 2));
        }
        private float EaseInOutCirc(float x)
        {
            return x < 0.5
                ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * x, 2))) / 2
                : (Mathf.Sqrt(1 - Mathf.Pow(-2 * x + 2, 2)) + 1) / 2;
        }
        
        // Elastic
        private float EaseInElastic(float x)
        {
            float c4 = (2 * Mathf.PI) / 3;
            return x == 0
                ? 0
                : x == 1
                    ? 1
                    : -Mathf.Pow(2, 10 * x - 10) * Mathf.Sin((x * 10 - 10.75f) * c4);
        }
        private float EaseOutElastic(float x)
        {
            float c4 = (2 * Mathf.PI) / 3;

            return x == 0
                ? 0
                : x == 1
                    ? 1
                    : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1;
        }
        private float EaseInOutElastic(float x)
        {
            float c5 = (2 * Mathf.PI) / 4.5f;

            return x == 0
                ? 0
                : x == 1
                    ? 1
                    : x < 0.5f
                        ? -(Mathf.Pow(2, 20 * x - 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2
                        : (Mathf.Pow(2, -20 * x + 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2 + 1;
        }
        
        // Quad
        private float EaseInQuad(float x)
        {
            return x * x;
        }
        private float EaseOutQuad(float x)
        {
            return 1 - (1 - x) * (1 - x);
        }
        private float EaseInOutQuad(float x)
        {
            return x < 0.5f ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
        }
        
        // Quart
        private float EaseInQuart(float x)
        {
            return x * x * x * x;
        }
        private float EaseOutQuart(float x)
        {
            return 1 - Mathf.Pow(1 - x, 4);
        }
        private float EaseInOutQuart(float x)
        {
            return x < 0.5 ? 8 * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
        }
        
        // Expo
        private float EaseInExpo(float x)
        {
            return x == 0 ? 0 : Mathf.Pow(2, 10 * x - 10);
        }
        private float EaseOutExpo(float x)
        {
            return x == 1 ? 1 : 1 - Mathf.Pow(2, -10 * x);
        }
        private float EaseInOutExpo(float x)
        {
            return x == 0
                ? 0
                : x == 1
                    ? 1
                    : x < 0.5 ? Mathf.Pow(2, 20 * x - 10) / 2
                        : (2 - Mathf.Pow(2, -20 * x + 10)) / 2;
        }
        
        // Back
        private float EaseInBack(float x)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1;

            return c3 * x * x * x - c1 * x * x;
        }
        private float EaseOutBack(float x)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1;

            return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
        }
        private float EaseInOutBack(float x)
        {
            float c1 = 1.70158f;
            float c2 = c1 * 1.525f;

            return x < 0.5
                ? (Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2
                : (Mathf.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
        }
        
        // Bounce
        private float EaseInBounce(float x)
        {
            return 1 - EaseOutBounce(1 - x);
        }
        private float EaseOutBounce(float x)
        {
            float n1 = 7.5625f;
            float d1 = 2.75f;

            if (x < 1 / d1) {
                return n1 * x * x;
            } else if (x < 2 / d1) {
                return n1 * (x -= 1.5f / d1) * x + 0.75f;
            } else if (x < 2.5f / d1) {
                return n1 * (x -= 2.25f / d1) * x + 0.9375f;
            } else {
                return n1 * (x -= 2.625f / d1) * x + 0.984375f;
            }
        }
        private float EaseInOutBounce(float x)
        {
            return x < 0.5
                ? (1 - EaseOutBounce(1 - 2 * x)) / 2
                : (1 + EaseOutBounce(2 * x - 1)) / 2;
        }
        #endregion
    }
}