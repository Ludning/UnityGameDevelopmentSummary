using System.Diagnostics;

namespace Util
{
    public static class DebuggingUtilities
    {
        [Conditional("DEV_VER")]
        public static void Log(string msg)
        {
            UnityEngine.Debug.LogFormat($"[{System.DateTime.Now:yyyy-mm-dd HH:mm:ss.fff}] {msg}");
        }
        [Conditional("DEV_VER")]
        public static void LogWarning(string msg)
        {
            UnityEngine.Debug.LogWarningFormat($"[{System.DateTime.Now:yyyy-mm-dd HH:mm:ss.fff}] {msg}");
        }
        [Conditional("DEV_VER")]
        public static void LogError(string msg)
        {
            UnityEngine.Debug.LogErrorFormat($"[{System.DateTime.Now:yyyy-mm-dd HH:mm:ss.fff}] {msg}");
        }
    }
}