namespace Core
{
    using UnityEngine;

    public class LogDebug : MonoBehaviour
    {
        public void DisplayLogDebug (string log)
        {
            Debug.Log(log);
        }
    }
}