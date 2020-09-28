namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;

    public class Flow : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] UnityEvent unityEvent;

        public void NextFlow()
        {
            unityEvent.Invoke();
        }
    }
}