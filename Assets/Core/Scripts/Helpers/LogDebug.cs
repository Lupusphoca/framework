namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;

    public class LogDebug : MonoBehaviour
    {
        /// <summary>
        /// Display a string in the console log
        /// </summary>
        /// <param name="log">Message to show in console log</param>
        public void DisplayLogDebug (string log)
        {
            Debug.Log(log);
        }
    }
}