namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;

    public class FrameExecutionUpdate : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] UnityEvent unityEvent;

        private void Update()
        {
            unityEvent.Invoke();
        }
    }
}