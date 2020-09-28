namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    class OnAwakeComponent : MonoBehaviour
    {
        [SerializeField] UnityEvent onAwake;

        private void Awake() => onAwake.Invoke();
    }
}