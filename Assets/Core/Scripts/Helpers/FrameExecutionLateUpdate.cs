namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;

    public class FrameExecutionLateUpdate : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] UnityEvent unityEvent;

        private void LateUpdate()
        {
            unityEvent.Invoke();
        }
    }
}