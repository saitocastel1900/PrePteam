using UnityEngine;

namespace Commons.Utility
{
    /// <summary>
    /// 将来的に#ifとかで分岐するのを予想して、
    /// Debugをラップ
    /// </summary>
    public static class DebugUtility
    {
        /// <summary>
        /// エラーログ
        /// </summary>
        public static void LogError(string message)
        {
            //#if
            Debug.LogError(message);
        }

        /// <summary>
        /// デバッグログ
        /// </summary>
        public static void Log(string message)
        {
            Debug.Log(message);
        }

    }
}