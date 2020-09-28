namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    class OnStartComponent : MonoBehaviour
    {
        [SerializeField] UnityEvent onStart;

        private void Start() => onStart.Invoke();
    }
}