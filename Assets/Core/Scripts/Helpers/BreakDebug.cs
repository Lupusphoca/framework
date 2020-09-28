namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;

    public class BreakDebug : MonoBehaviour
    {
        /// <summary>
        /// Pause the editor
        /// </summary>
        public void Break ()
        {
            Debug.Break();
        }
    }
}