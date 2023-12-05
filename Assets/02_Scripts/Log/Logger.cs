using System;
using UnityEngine;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using Debug = UnityEngine.Debug;

namespace Log
{
    public static class Logger
    {
        /** <summary>
         * 기본 로그 - 클래스 이름을 가져와서 로그를 띄움(클래스로 구분 가능)
         * </summary>
         * <param name="message">로그로 띄울 메세지</param>
         * <param name="isShowClassName">클래스 이름을 보여줄 지 여부</param>
         */
        public static void Log(string message, bool isShowClassName = true)
        {
            MethodBase methodBase = new StackTrace().GetFrame(1).GetMethod();
            if (methodBase.ReflectedType != null)
            {
                string className = methodBase.ReflectedType.FullName;
                if (isShowClassName)
                {
                    Debug.LogFormat("[{0}] - {1}", className,  message);
                }
                else
                {
                    Debug.Log(message);
                }
            }
        }
        
        /** <summary>
         * 기본 로그(색) - 클래스 이름을 가져와서 로그를 띄움(클래스로 구분 가능)
         * </summary>
         * <param name="message">로그로 띄울 메세지</param>
         * <param name="isShowClassName">클래스 이름을 보여줄 지 여부</param>
         * <param name="isPretty">클래스 이름에 색을 넣을지 여부</param>
         * <param name="color">클래스 이름 색</param>
         */
        public static void Log(string message, Color color,bool isShowClassName = true, bool isPretty = false)
        {
            MethodBase methodBase = new StackTrace().GetFrame(1).GetMethod();
            if (methodBase.ReflectedType != null)
            {
                string className = methodBase.ReflectedType.FullName;
                if (isShowClassName)
                {
                    if (isPretty)
                    {
                        Debug.LogFormat("<color=#{2}>[{0}]</color> - {1}", className,  message, ColorUtility.ToHtmlStringRGB(color));
                    }
                    Debug.LogFormat("[{0}] - {1}", className,  message);
                }
                else
                {
                    Debug.Log(message);
                }
            }
        }

        /**
         * <summary>
         * 경고 로그 - 클래스 이름을 가져와서 경고를 띄움(클래스로 구분 가능)
         * </summary>
         * <param name="message">로그로 띄울 메세지</param>
         * <param name="isShowClassName">클래스 이름을 보여줄 지 여부</param>
         */
        public static void LogWarning(string message, bool isShowClassName = true)
        {
            MethodBase methodBase = new StackTrace().GetFrame(1).GetMethod();
            if (methodBase.ReflectedType != null)
            {
                if(isShowClassName){
                    string className = methodBase.ReflectedType.FullName;
                    Debug.LogWarningFormat("[{0}] - {1}", className,  message);
                }
                else
                {
                    Debug.LogWarning(message);
                }
            }
        }

        /**
         * <summary>
         * 에러 로그 - 클래스 이름을 가져와서 에러를 띄움(클래스로 구분 가능)
         * </summary>
         * <param name="message">로그로 띄울 메세지</param>
         * <param name="isShowClassName">클래스 이름을 보여줄 지 여부</param>
         */
        public static void LogError(string message, bool isShowClassName = true)
        {
            MethodBase methodBase = new StackTrace().GetFrame(1).GetMethod();
            if (methodBase.ReflectedType != null)
            {
                if (isShowClassName){
                    string className = methodBase.ReflectedType.FullName;
                    Debug.LogErrorFormat("오류 발생: [{0}] - {1} At {0}.{2}", className,  message, methodBase);
                }
                else
                {
                    Debug.LogError(message);
                }
            }
        }

        /**
         * <summary>
         * 예외 로그 - 클래스 이름을 가져와서 예외를 띄움
         * </summary>
         * <param name="exception">예외로 보낼 문자열</param>
         */
        public static void LogException(string exception)
        {
            throw new Exception(exception);
        }

        /** <summary>
         * 역 로그 - 로그를 거꾸로 띄움(역으로 읽을 수 있음)
         * </summary>
         * <param name="message">로그로 띄울 메세지</param>
         */
        public static void ReverseLog(string message)
        {
            char[] message2 = new char[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                message2[i] = message[message.Length - 1 - i];
            }
            Log(new string(message2), false);
        }

        /**
         * <summary>
         * 색 로그 - 색을 지정해서 로그를 띄움(색으로 구분 가능)
         * </summary>
         * <param name="message">로그로 띄울 메세지</param>
         * <param name="color">로그의 색</param>
         * <param name="isShowClassName">클래스 이름을 띄워줄 지 여부</param>
         */
        public static void ColorLog(string message, Color color, bool isShowClassName = true)
        {
            MethodBase methodBase = new StackTrace().GetFrame(1).GetMethod();
            if (methodBase.ReflectedType != null)
            {
                if (isShowClassName)
                {
                    string className = methodBase.ReflectedType.FullName;
                    Debug.LogFormat("<color=#{0}> [{1}] - {2}</color>", ColorUtility.ToHtmlStringRGB(color), className,
                        message);
                }
                else
                {
                    Debug.LogFormat("<color=#{0}>{1}</color>", ColorUtility.ToHtmlStringRGB(color), message);
                }
            }
        }
        
        /** <summary>
         * 무지개 로그 - 무지개 색으로 로그를 띄움(예쁘다)
         * </summary>
         * <param name="message">로그로 띄울 메세지</param>
         */
        public static void RainbowLog(string message)
        {
            string message2 = "";
            char[] message3 = new char[message.Length];
            
            for (int i = 0; i < message.Length; i++)
            {
                message3[i] = message[i];
                Color rainbowColor = GetRainbowColor(i, message.Length);
                message2 += $"<color=#{ColorToHex(rainbowColor)}>{message3[i]}</color>";
            }
            Debug.Log(message2);
        }
        
        /**
         * <summary>
         * 무지개 색을 가져옴
         * </summary>
         */
        private static Color GetRainbowColor(int index, int totalLength)
        {
            float hue = (float)index / totalLength;
            return Color.HSVToRGB(hue, 1f, 1f);
        }
        
        /**
         * <summary>
         * 색을 16진수로 변환
         * </summary>
         */
        private static string ColorToHex(Color color)
        {
            int r = (int)(color.r * 255);
            int g = (int)(color.g * 255);
            int b = (int)(color.b * 255);
            return $"{r:X2}{g:X2}{b:X2}";
        }
        
        /**
         * <summary>
         * 로그로 띄울 문자열을 Log.Log() 함수의 인자로 넣을 수 있게 해줌
         * </summary>
         */
        public static string ToLog(this string message)
        {
            Log(message, false);
            return message;
        }

        /**
         * <summary>
         * 로그로 띄울 문자열을 Log.ColorLog() 함수의 인자로 넣을 수 있게 해줌
         * </summary>
         */
        public static string ToLog(this string message, Color color)
        {
            ColorLog(message, color, false);
            return message;
        }
        
        /**
         * <summary>
         * 로그로 띄울 문자열을 바로 경고로 띄워줌
         * </summary>
         */
        public static string ToWarning(this string message)
        {
            LogWarning(message, false);
            return message;
        }

        /**
         * <summary>
         * 로그로 띄울 문자열을 바로 에러로 띄워줌
         * </summary>
         */
        public static string ToError(this string message)
        {
            LogError(message, false);
            return message;
        }

        /**
         * <summary>
         * 파일 로그 - 실행 파일이 있는 폴더에 Logs 폴더를 생성하고, log.txt 파일에 로그를 기록함
         * </summary>
         * <param name="message">파일에 적을 메세지</param>
         */
        public static void FileLog(string message)
        {
            string logFolderPath = Path.Combine(Application.persistentDataPath, "Logs");
            string logFileName = $"log_{DateTime.Now:yyyyMMdd}.txt";
            string logFilePath = Path.Combine(logFolderPath, logFileName);

            if (!Directory.Exists(logFolderPath))
            {
                Directory.CreateDirectory(logFolderPath);
            }

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now} - {message}");
            }
        }
        
        /**
         * <summary>
         * 파일 로그 - 실행 파일이 있는 폴더에 Logs 폴더를 생성하고, log.txt 파일에 로그를 기록함(클래스 이름을 보여줌)
         * </summary>
         * <param name="message">파일에 적을 메세지</param>
         * <param name="isShowClassName">클래스 이름을 보여줄 지 여부</param>
         */
        public static void FileLog(string message, bool isShowClassName)
        {
            MethodBase methodBase = new StackTrace().GetFrame(1).GetMethod();
            if (methodBase.ReflectedType != null)
            {
                string className = methodBase.ReflectedType.FullName;
                FileLog(isShowClassName ? $"[{className}] - {message}" : message);
            }
        }
        
        
    }
}
