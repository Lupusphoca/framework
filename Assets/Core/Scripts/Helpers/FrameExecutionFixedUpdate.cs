namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;

    public class FrameExecutionFixedUpdate : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] UnityEvent unityEvent;

        private void FixedUpdate()
        {
            unityEvent.Invoke();
        }
    }
}