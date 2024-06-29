using UnityEngine;

namespace Commons.Utility
{
    public static class DebugUtility
    {
        /// <summary>
        /// エラーログ
        /// </summary>
        public static void LogError(string message)
        {
#if UNITY_EDITOR
            Debug.LogError($"<color=magenta>{message}</color>");
#endif
        }

        /// <summary>
        /// デバッグログ
        /// </summary>
        public static void Log(string message)
        {
            {
#if UNITY_EDITOR
                Debug.Log($"<color=green>{message}</color>");
#endif
            }
        }
    }
}